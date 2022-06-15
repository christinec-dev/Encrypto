using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;namespace Encrypto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //do the actual cyphering of texts
        private static string doEncryption(string words, int shiftValue)
        {
            //will help us turn our string int individual chars(letters) so that we can shift them
            char[] letters = words.ToCharArray();

            //we will loop through the alphapet and encrypt the text
            for (int i = 0; i < letters.Length; i++)
            { 
                {
                    //each letter of our buffer array
                    char letter = letters[i];
                    letter = (char)(letter + shiftValue);

                    //shift through 26 letters (FROM A TO Z)
                    if (letter > 'z')
                    {
                        letter = (char)(letter - 26);
                    }
                    else if (letter < 'a')
                    {
                        letter = (char)(letter + 26);
                    }

                    //assign the char with the new letter
                    letters[i] = letter;
                }
            }
            //return our new string of characters
            return new string(letters);
        }

        //will call our encryption method and actually execute it
        private void buttonEncrypt_Click(object sender, EventArgs e)
        {
            //sets text entered
            string originalMessage = textBoxOriginal.Text;

            //sets shift number
            int shiftNumber = Int32.Parse(textBoxShift.Text);

            //sets text encrypted
            textBoxEncrypted.Text = doEncryption(originalMessage.ToLower(), shiftNumber);
        }

        //will show our help menu form
        private void helpToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            HelpScreen helpScreen = new HelpScreen();
            helpScreen.Show();
        }

        //will close our form
        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}