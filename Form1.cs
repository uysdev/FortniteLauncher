using Protection;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Diagnostics;

namespace FortniteLauncher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private int FNPID()
        {

            foreach (Process process in Process.GetProcesses())
            {
                if (process.ProcessName == "FortniteClient-Win64-Shipping")
                {
                    return process.Id;
                }
            }
            return 0;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string BEExecutablePath = Path.Combine(textBox1.Text, "Binaries", "Win64", "FortniteClient-Win64-Shipping_BE.exe");
            string LAExecutablePath = Path.Combine(textBox1.Text, "Binaries", "Win64", "FortniteLauncher.exe");
            string FNExecutablePath = Path.Combine(textBox1.Text, "Binaries", "Win64", "FortniteClient-Win64-Shipping.exe");
            Process.Start(new ProcessStartInfo
            {
                FileName = BEExecutablePath,
                WindowStyle = ProcessWindowStyle.Hidden,
                UseShellExecute = false,
            });
            Process.Start(new ProcessStartInfo
            {
                FileName = LAExecutablePath,
                WindowStyle = ProcessWindowStyle.Hidden,
                UseShellExecute = false,
            });
            Process.Start(new ProcessStartInfo
            {
                FileName = FNExecutablePath,
                UseShellExecute = false,
                Arguments = $"-AUTH_LOGIN={textBox3.Text} -AUTH_PASSWORD={textBox2.Text} -AUTH_TYPE=epic -epicapp=Fortnite -epicenv=Prod -epiclocale=en-us -epicportal -skippatchcheck -nobe -fltoken=3db3ba5dcbd2e16703f3978d -caldera=eyJhbGciOiJFUzI1NiIsInR5cCI6IkpXVCJ9.eyJhY2NvdW50X2lkIjoiYmU5ZGE1YzJmYmVhNDQw7DBjnzDnXyyEnX7OljJm-j2d88G_WgwQ9wrE6lwMEHZHjBd1ISJdUO1UVUqkfLdU5nofBQ -fromfl=eac"
            });
            string dllPath = "assets/dlls/ssl.dll";
            int fnpid = FNPID();
            Inject.InjectProtection(fnpid, dllPath);
            MessageBox.Show("fortnite started succesfully.");
        }
    }
}
