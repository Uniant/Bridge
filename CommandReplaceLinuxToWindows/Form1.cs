using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections.Generic;
using System.Text.Json;

namespace CommandReplaceLinuxToWindows {
    public partial class Form1 : Form {
        public Form1 () {
            InitializeComponent();
        }

        private void label1_Click (object sender, EventArgs e) {

        }

        private void passedCommandBox_TextChanged (object sender, EventArgs e) {

        }

        private void runButton_Click (object sender, EventArgs e) {
            var runCommand = "";
            runCommand = ReplaceCommandIsSudo(passedCommandBox.Text);
            if (runCommand != null) {
                // label2.Text = runCommand;
                // Console.WriteLine(runCommand);
                ProcessStartInfo processStartInfo = new ProcessStartInfo("cmd.exe", "/k " + runCommand);
                // コマンド実行
                Process.Start(processStartInfo);
            }
        }
        public string ReplaceCommandIsSudo (string passedCommand) {
            var replacedCommand = "";
            // 受け取った文字列（passedCommand）を分割、配列 commandsAll に格納
            String[] commandsAll = passedCommand.Split(' ');
            // Console.WriteLine(commandsAll.Length); // テスト用
            if (commandsAll.Length < 2) {
                // コマンドにスペースで区切られる部分があるか判断
                replacedCommand = passedCommand.Replace("pwd", "dir").Replace("mv", "move").Replace("cp", "copy").Replace("rm", "del").Replace("less", "type").Replace("date", "time").Replace("ifconfig", "ipconfig").Replace("clear", "cls").Replace("ls", "dir").Replace("df", "fsutil volume diskfree").Replace("diff", "fc").Replace("rsync", "robocopy").Replace("ps", "tasklist").Replace("kill", "taskkill").Replace("killall", "taskkill /im").Replace("grep", "findstr").Replace("sar", "logman").Replace("vmstat", "logman").Replace("iostat", "logman").Replace("top", "taskmgr").Replace("env", "set").Replace("printenv", "set").Replace("which", "where").Replace("traceroute", "tracert");
                return replacedCommand;
            } else {
                if (commandsAll[0] == "sudo") {
                    var runningCommand = "";
                    var passedCommandWithSudo = "";
                    for (int i = 1; i < commandsAll.Length; i++) {
                        passedCommandWithSudo += commandsAll[i] + ' ';
                    }
                    passedCommandWithSudo = passedCommandWithSudo.Remove(passedCommandWithSudo.Length - 1);
                    // Console.WriteLine(passedCommandWithSudo);
                    runningCommand = ReplaceCommand(passedCommandWithSudo);
                    ProcessStartInfo processStartInfo = new ProcessStartInfo("cmd.exe", "/k " + runningCommand);
                    // コマンド実行　管理者権限で実行
                    processStartInfo.Verb = "RunAs";
                    Process.Start(processStartInfo);
                    return null;
                } else {
                    replacedCommand = ReplaceCommand(passedCommand);
                    return replacedCommand;
                }
            }

        }

        public string ReplaceCommand (string passedCommand) {
            /* var dic = new Dictionary<string, string>()
            {   { "mv-r", "move"},
                { "cp -r", "xcopy /e/c/h"},
                { "rm -r", "del"},
                { "ls -al", "dir"},
                { "uname -a", "ver"},
                { "ls -1", "dir /b"},
                { "ls -lF", "dir /ad"},
                { "ls -ltr", "dir /od"},
                { "ls -lt", "dir /o-d"},
                { "grep -i", "grep /i"},
                { "ifconfig -a", "ifconfig /a"},
                { "cp -r foo bar", "xcopy foo bar /s/e/i/q"},
                { "rm -fr", "rd /s /q" },
                { "cat", "type"},
                { "cat /proc/cpuinfo", "systeminfo"},
                { "cat /proc/meminfo", "systeminfo"},
                { "pwd", "dir"},
                { "mv", "move"},
                { "cp", "copy"},
                { "rm", "del"},
                { "less", "type"},
                { "date", "time"},
                { "ifconfig", "ipconfig"},
                { "clear", "cls"},
                { "ls", "dir"},
                { "df", "fsutil volume diskfree"},
                { "diff", "fc"},
                { "rsync", "robocopy"},
                { "ps", "tasklist"},
                { "kill", "taskkill"},
                { "killall", "taskkill /im"},
                { "grep", "findstr"},
                { "sar", "logman"},
                { "vmstat", "logman"},
                { "iostat", "logman"},
                { "top", "taskmgr"},
                { "env", "set"},
                { "printenv", "set"},
                { "which", "where"},
                { "traceroute", "tracert"}
            };

            var jsonstr = JsonSerializer.Serialize(dic);
            var dictionary = new Dictionary<string, string>(); */

            var replacedCommand = "";
            // 受け取った文字列（passedCommand）を分割、配列 commandsAll に格納
            String[] commandsAll = passedCommand.Split(' ');
            // Console.WriteLine(commandsAll.Length); テスト用
            if (commandsAll[1].Substring(0, 1) == "-") {
                // オプションの有無を判断するため、配列の 1 番目の文字列が - で始まるか確かめる
                // Console.WriteLine("B-1");
                // オプションを含めて一気に置換するので、オプションまで含めた文字列を commandsAlls に代入
                var commandsAlls = commandsAll[0] + ' ' + commandsAll[1];
                // commandsAlls に代入されたコマンドを Windows 用に置換、replacedCommand に代入
                replacedCommand = commandsAlls.Replace("mv -r", "move").Replace("cp -r", "xcopy /e /c /h").Replace("rm -r", "del").Replace("ls -al", "dir").Replace("uname -a", "ver").Replace("ls -1", "dir /b").Replace("ls -lF", "dir /ad").Replace("ls -ltr", "dir /od").Replace("ls -lt", "dir /o-d").Replace("grep -i", "grep /i").Replace("ifconfig -a", "ifconfig /a").Replace("cp -r foo bar", "xcopy foo bar /s/e/i/q").Replace("rm -fr", "rd /s /q");
                for (int i = 2; i < commandsAll.Length; i++) {
                    replacedCommand += ' ' + commandsAll[i];
                }
                return replacedCommand;
            } else if (commandsAll[0] == "cat") {
                // コマンドの最初の指令が cat の場合　cat の場合はたいていパスが後に来るので別物として考えます
                // cat, cat /proc/cpuinfo, 
                replacedCommand = commandsAll[0].Replace("cat", "type").Replace("cat /proc/cpuinfo", "systeminfo").Replace("cat /proc/meminfo", "systeminfo");
                return replacedCommand;
            } else if (commandsAll[1] == "--help") {
                // --help がついている場合　replace だけだと厳しそうだと感じたので別にしてやります
                replacedCommand = "help" + commandsAll[0];
                return replacedCommand;
            } else {
                // commandsAll の 0 番目を Linux 用コマンドから Windows 用コマンドに置換、replacedCommand にすべて代入
                // pwd, mv, cp, rm, less, date, ifconfig, clear, ls, df, diff, rsync, ps, kill, killall, grep
                replacedCommand = commandsAll[0].Replace("pwd", "dir").Replace("mv", "move").Replace("cp", "copy").Replace("rm", "del").Replace("less", "type").Replace("date", "time").Replace("ifconfig", "ipconfig").Replace("clear", "cls").Replace("ls", "dir").Replace("df", "fsutil volume diskfree").Replace("diff", "fc").Replace("rsync", "robocopy").Replace("ps", "tasklist").Replace("kill", "taskkill").Replace("killall", "taskkill /im").Replace("grep", "findstr").Replace("sar", "logman").Replace("vmstat", "logman").Replace("iostat", "logman").Replace("top", "taskmgr").Replace("env", "set").Replace("printenv", "set").Replace("which", "where").Replace("traceroute", "tracert").Replace("wget", "bitsadmin");
                for (int i = 1; i < commandsAll.Length; i++) {
                    replacedCommand += ' ' + commandsAll[i];
                }
                return replacedCommand;
            }
        }

        private void label2_Click (object sender, EventArgs e) {

        }
    }
}