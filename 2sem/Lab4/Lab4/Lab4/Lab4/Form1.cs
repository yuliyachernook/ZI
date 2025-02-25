﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab4
{
    public partial class Form1 : Form
    {
        string alphabet = "abcdefghijklmnopqrstuvwxyz";
        char rotRPos = 'q';
        char rotMPos = 'u';
        char rotLPos = 'c';

        public Form1()
        {
            InitializeComponent();
            foreach(char letter in alphabet)
            {
                rRotList.Items.Add(letter);
                lRotList.Items.Add(letter);
                mRotList.Items.Add(letter);
            }
            rRotList.SelectedItem = 'a';
            mRotList.SelectedItem = 'a';
            lRotList.SelectedItem = 'a';
        }

        private char Encrytp(char letter, char rPos, char mPos, char lPos)
        {
            //L-M-R
            rotRPos = alphabet[(alphabet.IndexOf(rPos) + 2)%26];
            rRotList.SelectedItem = rotRPos;
            rotMPos = alphabet[(alphabet.IndexOf(mPos) + 1)%26];
            mRotList.SelectedItem = rotMPos;
            rotLPos = alphabet[(alphabet.IndexOf(lPos) + 1)%26]; 
            lRotList.SelectedItem = rotLPos;

            string rotorR = "vzbrgityupsdnhlxawmjqofeck"; // 5 ротор
            string rotorM = "fsokanuerhmbtiycwlqpzxvgjd"; // gamma
            string rotorL = "bdfhjlcprtxvznyeiwgakmusqo"; // 3 ротор 
            string reflectorCDunn = "ar-bd-co-ej-fn-gt-hk-iv-lm-pw-qz-sx-uy-"; //c dunn

            int index = (alphabet.IndexOf(letter) + alphabet.IndexOf(rotRPos)) % 26;
            char newLetter = rotorR[index];
            if ((alphabet.IndexOf(newLetter) + (alphabet.IndexOf(rotMPos) - alphabet.IndexOf(rotRPos))) < 0)
                index = (26 + alphabet.IndexOf(newLetter) + (alphabet.IndexOf(rotMPos) - alphabet.IndexOf(rotRPos))) % 26;
            else
                index = (alphabet.IndexOf(newLetter) + (alphabet.IndexOf(rotMPos) - alphabet.IndexOf(rotRPos))) % 26;
            newLetter = rotorM[index];
            if ((alphabet.IndexOf(newLetter) + (alphabet.IndexOf(rotLPos) - alphabet.IndexOf(rotMPos))) < 0)
                index = (26 + (alphabet.IndexOf(newLetter) + (alphabet.IndexOf(rotLPos) - alphabet.IndexOf(rotMPos)))) % 26;
            else
                index = (alphabet.IndexOf(newLetter) + (alphabet.IndexOf(rotLPos) - alphabet.IndexOf(rotMPos))) % 26;
            newLetter = rotorL[index];
            if((alphabet.IndexOf(newLetter) - alphabet.IndexOf(lPos)) < 0)
                newLetter = alphabet[(26 + (alphabet.IndexOf(newLetter) - alphabet.IndexOf(lPos))) % 26];
            else
                newLetter = alphabet[(alphabet.IndexOf(newLetter) - alphabet.IndexOf(lPos)) % 26];
            newLetter = reflectorCDunn[reflectorCDunn.IndexOf(newLetter) + 1] == '-' ? reflectorCDunn[reflectorCDunn.IndexOf(newLetter) - 1] : reflectorCDunn[reflectorCDunn.IndexOf(newLetter) + 1];
            index = (alphabet.IndexOf(newLetter) + alphabet.IndexOf(lPos)) % 26;
            newLetter = alphabet[index];
            index = rotorL.IndexOf(newLetter);
            newLetter = alphabet[index];
            if (alphabet.IndexOf(newLetter) - (alphabet.IndexOf(rotLPos) - alphabet.IndexOf(rotMPos)) < 0)
                index = (26 + (alphabet.IndexOf(newLetter) - (alphabet.IndexOf(rotLPos) - alphabet.IndexOf(rotMPos)))) % 26;
            else
                index = (alphabet.IndexOf(newLetter) - (alphabet.IndexOf(rotLPos) - alphabet.IndexOf(rotMPos))) % 26;
            newLetter = alphabet[index];
            index = rotorM.IndexOf(newLetter);
            newLetter = alphabet[index];

            if (alphabet.IndexOf(newLetter) - (alphabet.IndexOf(rotMPos) - alphabet.IndexOf(rotRPos)) < 0)
                index = (26 + (alphabet.IndexOf(newLetter) - (alphabet.IndexOf(rotMPos) - alphabet.IndexOf(rotRPos)))) % 26;
            else
                index = (alphabet.IndexOf(newLetter) - (alphabet.IndexOf(rotMPos) - alphabet.IndexOf(rotRPos))) % 26;
            newLetter = alphabet[index];
            index = rotorR.IndexOf(newLetter);
            newLetter = alphabet[index];

            if (alphabet.IndexOf(newLetter) - alphabet.IndexOf(rotRPos) < 0)
                index = (26 + (alphabet.IndexOf(newLetter) - alphabet.IndexOf(rotRPos))) % 26;
            else
                index = (alphabet.IndexOf(newLetter) - alphabet.IndexOf(rotRPos)) % 26;
            newLetter = alphabet[index];
            return newLetter;
        }

        private void encrytpBtnClick(object sender, EventArgs e)
        {
            rotRPos = rRotList.Text.ToCharArray()[0];
            rotMPos = mRotList.Text.ToCharArray()[0];
            rotLPos = lRotList.Text.ToCharArray()[0];
            textToEncypt.Text +=(sender as Button).Text.ToLower().ToCharArray()[0];
            encryptedText.Text += Encrytp((sender as Button).Text.ToLower().ToCharArray()[0], rotRPos, rotMPos, rotLPos);
        }

        private void textToEncypt_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
