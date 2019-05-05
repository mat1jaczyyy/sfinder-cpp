﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using MisaMinoNET;
using PerfectClearNET;

namespace Tester {
    public partial class MainForm: Form {
        public MainForm() => InitializeComponent();

        int[,] field = new int[10, 40] {
            {0,   0,   255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255},
            {0,   0,   255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255},
            {0,   0,   255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255},
            {0,   0,   255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255},
            {0,   255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255},
            {255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255},
            {0,   255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255},
            {0,   0,   255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255},
            {0,   0,   255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255},
            {0,   0,   255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255, 255},
        };

        private void Finished(bool success) {
            Display.Text = $"{PerfectClear.LastTime}ms {success.ToString()}";

            if (success) {
                Display.Text += $" => {string.Join("; ", PerfectClear.LastSolution.Select(i => i.ToString()))} ";

                bool spinUsed = false;

                List<Instruction> result = MisaMino.FindPath(
                    field,
                    21,
                    PerfectClear.LastSolution[0].Piece,
                    PerfectClear.LastSolution[0].X,
                    PerfectClear.LastSolution[0].Y,
                    PerfectClear.LastSolution[0].R,
                    false,
                    ref spinUsed
                );

                Display.Text += string.Join(", ", result);
            }
        }

        private void MainForm_Load(object sender, EventArgs e) {
            PerfectClear.Finished += (bool success) => {
                if (Display.InvokeRequired)
                    Invoke(new PerfectClear.FinishedEventHandler(Finished), new object[] { success });
                else
                    Finished(success);
            };
        }

        private void Run_Click(object sender, EventArgs e) {
            Display.Text = "Started";

            PerfectClear.Find(field, new int[] { 0, 2, 3, 6 }, 4, null);
        }
    }
}
