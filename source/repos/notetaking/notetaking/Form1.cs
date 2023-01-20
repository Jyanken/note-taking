using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace notetaking
{
    public partial class Notetaking : Form
    {
        DataTable note = new DataTable();
        bool editing = false;
        public Notetaking()
        {
            InitializeComponent();
        }

        private void Notetaking_Load(object sender, EventArgs e)
        {
            note.Columns.Add("Title");
            note.Columns.Add("Note");

            previousNotes.DataSource = note;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            try
            {
                note.Rows[previousNotes.CurrentCell.RowIndex].Delete();
            }
            catch(Exception ex) { Console.WriteLine("Not a valid note"); }
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            titleBox.Text = note.Rows[previousNotes.CurrentCell.RowIndex].ItemArray[0].ToString();
            notesBox.Text = note.Rows[previousNotes.CurrentCell.RowIndex].ItemArray[1].ToString();
            editing = true;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if(editing)
            {
                note.Rows[previousNotes.CurrentCell.RowIndex]["Title"] = titleBox.Text;
                note.Rows[previousNotes.CurrentCell.RowIndex]["Note"] = notesBox.Text;
            }
            else
            {
                note.Rows.Add(titleBox.Text, notesBox.Text);
            }
            titleBox.Text = "";
            notesBox.Text = "";
            editing = false;
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            titleBox.Text = "";
            notesBox.Text = "";
        }

        private void previousNotes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            titleBox.Text = note.Rows[previousNotes.CurrentCell.RowIndex].ItemArray[0].ToString();
            notesBox.Text = note.Rows[previousNotes.CurrentCell.RowIndex].ItemArray[1].ToString();
            editing = true;
        }
    }
}
