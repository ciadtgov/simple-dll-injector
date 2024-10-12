using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace dllinjector1
{
    public partial class form1 : Form
    {
        public form1()
        {
            InitializeComponent();
        }

        // Importing necessary Windows API functions for DLL injection
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, out IntPtr lpNumberOfBytesWritten);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttributes, uint dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern uint WaitForSingleObject(IntPtr hHandle, uint dwMilliseconds);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool CloseHandle(IntPtr hObject);

        private const int PROCESS_ALL_ACCESS = 0x1F0FFF;
        private const uint MEM_COMMIT = 0x1000;
        private const uint MEM_RESERVE = 0x2000;
        private const uint PAGE_READWRITE = 0x04;
        private const uint INFINITE = 0xFFFFFFFF;

        // Button click event for DLL injection
        private void btnInject_Click(object sender, EventArgs e)
        {
            int pid;
            if (!int.TryParse(txtProcessId.Text, out pid))
            {
                MessageBox.Show("Please enter a valid Process ID (PID).", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string dllPath = txtDllPath.Text;
            if (string.IsNullOrEmpty(dllPath))
            {
                MessageBox.Show("Please enter a valid DLL path.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (InjectDLL(pid, dllPath))
            {
                MessageBox.Show("DLL Injection succeeded!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("DLL Injection failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Method to inject DLL into the target process
        private bool InjectDLL(int pid, string dllPath)
        {
            // Open the target process
            IntPtr hProcess = OpenProcess(PROCESS_ALL_ACCESS, false, pid);
            if (hProcess == IntPtr.Zero)
            {
                MessageBox.Show("Failed to open process.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Allocate memory in the target process for the DLL path
            IntPtr allocMemAddress = VirtualAllocEx(hProcess, IntPtr.Zero, (uint)dllPath.Length + 1, MEM_COMMIT | MEM_RESERVE, PAGE_READWRITE);
            if (allocMemAddress == IntPtr.Zero)
            {
                MessageBox.Show("Failed to allocate memory.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Write the DLL path to the allocated memory
            byte[] dllPathBytes = Encoding.ASCII.GetBytes(dllPath);
            if (!WriteProcessMemory(hProcess, allocMemAddress, dllPathBytes, (uint)dllPathBytes.Length, out _))
            {
                MessageBox.Show("Failed to write to process memory.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Get the address of LoadLibraryA from kernel32.dll
            IntPtr loadLibraryAddr = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");
            if (loadLibraryAddr == IntPtr.Zero)
            {
                MessageBox.Show("Failed to get address of LoadLibraryA.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Create a remote thread in the target process to call LoadLibraryA with the DLL path
            IntPtr remoteThread = CreateRemoteThread(hProcess, IntPtr.Zero, 0, loadLibraryAddr, allocMemAddress, 0, IntPtr.Zero);
            if (remoteThread == IntPtr.Zero)
            {
                MessageBox.Show("Failed to create remote thread.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Wait for the remote thread to complete
            WaitForSingleObject(remoteThread, INFINITE);

            // Close handles
            CloseHandle(remoteThread);
            CloseHandle(hProcess);

            return true;
        }

        // Button click event for Browse button
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "DLL files (*.dll)|*.dll|All files (*.*)|*.*",
                Title = "Select a DLL File"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtDllPath.Text = openFileDialog.FileName;
            }
        }

        private void btnBrowse_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "DLL files (*.dll)|*.dll|All files (*.*)|*.*",
                Title = "Select a DLL File"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtDllPath.Text = openFileDialog.FileName;
            }

        }
    }
}


