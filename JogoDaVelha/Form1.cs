using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JogoDaVelha {
    public partial class Form1 : Form {

        public bool venceuOuNao = false;

        public int rodada = 0;

        public char vez = 'X';

        public string posicaoJogada = "";
        public string registro = "";

        public int[,] tabuleiroX = new int[3,3];
        public int[,] tabuleiroO = new int[3,3];

        public Form1() {

            InitializeComponent();

        }

        private void botaoJogar(object sender, EventArgs e) {

            btJogar.Visible = false;
            gbEstrutura.Visible = true;
            gbRegistro.Visible = true;

        }

        private void botaoClicado(object sender, EventArgs e) {

            Button botao = (Button)sender;
            this.rodada++;

            this.posicaoJogada = botao.Name.Substring(2, 3).Replace("_", ", ");
            txtBoxRegistro.Text += "\r\n" + this.vez + " - Jogou na posição " + this.posicaoJogada;

            atribuirValoresTabuleiro(posicaoJogada.ToCharArray(), this.vez);
            atribuirImagem(botao);

            this.venceuOuNao = verificarTabuleiro(this.vez == 'X' ? tabuleiroX : tabuleiroO);

            if (this.venceuOuNao) {
                lbVez.Text = this.vez + " VENCEU!!!!!";
                txtBoxRegistro.Text += "\r\n" + this.vez + " - venceu";
                btJogarNovamente.Visible = true;
                bloquearTabuleiro();
            } else {
                if (this.rodada == 9) {
                    lbVez.Text = "EMPATE";
                    txtBoxRegistro.Text += "\r\n empatou";
                    btJogarNovamente.Visible = true;
                } else {
                    mudarVez();
                    lbVez.Text = "Vez de " + this.vez;
                }
            }
        }

        private void atribuirImagem(Button botao) {

            if (this.vez.Equals('X')) {
                botao.BackgroundImage = Properties.Resources.x;
            } else {
                botao.BackgroundImage = Properties.Resources.o;
            }

            botao.Enabled = false;

        }

        private void mudarVez() {

            this.vez = this.vez == 'O' ? 'X' : 'O';

        }

        private void atribuirValoresTabuleiro(char[] posicao, char vez) {

            int x = (int)Char.GetNumericValue(posicao[0]);
            int y = (int)Char.GetNumericValue(posicao[3]);

            if (vez == 'X') {
                this.tabuleiroX[x, y] = 1;
            } else {
                this.tabuleiroO[x, y] = 1;
            }
            
        }

        private bool verificarTabuleiro(int[,] tabuleiro) {
            
            //Verificar diagonais
            if (tabuleiro[0, 0] + tabuleiro[1, 1] + tabuleiro[2, 2] == 3) {
                return true;
            } else if (tabuleiro[2, 0] + tabuleiro[1, 1] + tabuleiro[0, 2] == 3) {
                return true;
            }

            //Verificar Linhas
            for (int x = 0; x < 2; x++) {
                if (tabuleiro[x, 0] + tabuleiro[x, 1] + tabuleiro[x, 2] == 3) {
                    return true;
                }
            }

            //Verificar Linhas
            for (int y = 0; y < 2; y++) {
                if (tabuleiro[0, y] + tabuleiro[1, y] + tabuleiro[2, y] == 3) {
                    return true;
                }
            }

            return false;

        }

        private void bloquearTabuleiro() {
            bt0_0.Enabled = false;
            bt0_1.Enabled = false;
            bt0_2.Enabled = false;
            bt1_0.Enabled = false;
            bt1_1.Enabled = false;
            bt1_2.Enabled = false;
            bt2_0.Enabled = false;
            bt2_1.Enabled = false;
            bt2_2.Enabled = false;
        }

        private void desbloquearTabuleiro() {
            bt0_0.Enabled = true;
            bt0_0.BackgroundImage = null;
            bt0_1.Enabled = true;
            bt0_1.BackgroundImage = null;
            bt0_2.Enabled = true;
            bt0_2.BackgroundImage = null;
            bt1_0.Enabled = true;
            bt1_0.BackgroundImage = null;
            bt1_1.Enabled = true;
            bt1_1.BackgroundImage = null;
            bt1_2.Enabled = true;
            bt1_2.BackgroundImage = null;
            bt2_0.Enabled = true;
            bt2_0.BackgroundImage = null;
            bt2_1.Enabled = true;
            bt2_1.BackgroundImage = null;
            bt2_2.Enabled = true;
            bt2_2.BackgroundImage = null;
        }

        private void jogarNovamente(object sender, EventArgs e) {

            btJogarNovamente.Visible = false;
            this.rodada = 0;
            this.tabuleiroO = new int[3, 3];
            this.tabuleiroX = new int[3, 3];
            this.vez = 'X';
            lbVez.Text = "Vez de X";
            txtBoxRegistro.Text = "";
            desbloquearTabuleiro();

        }
    }
}
