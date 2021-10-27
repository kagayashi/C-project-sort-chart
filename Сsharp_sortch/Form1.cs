using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt_2_Naumov_Nikita_49102
{
    public partial class Analiza : Form
    {
        //deklaracja zmiennych
        int NNprobaBadawcza = 100;
        int NNMaxRozmiarTablicy = 50;
        double NNDolnaGranicaWartosci = 20.0;
        double NNGornagranicawartosci = 300000.0;
        float[] NNWynikiZpomiaru;
        float[] NNWynikiAnalityczne;
        

        
        
        
        
        
        
        


        
       
        public Analiza()
        {
            InitializeComponent();
            //Startowe kolory i typ linii i tła wykresu
            NNTB_Kolor_linii.BackColor = Color.Black;
            NNTB_kolor_Tla.BackColor = Color.White;
            NNdrawline();//Funkcja rysowania wziemniku linii
            NNcomboBox_styl_linii.SelectedIndex = 0;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.AutoScroll = true;


            
            NNTB_minimalna_proba_badawcza.Text = NNprobaBadawcza.ToString();
            NNTB_maks_rozmiar_tab.Text = NNMaxRozmiarTablicy.ToString();
            NNTB_dolna_granica.Text = NNDolnaGranicaWartosci.ToString();
            NNTB_gorna_granica.Text = NNGornagranicawartosci.ToString();  // Startowe danne wprowadzane do programmy
            NNcombobox_algorytm.SelectedIndex = 0;





        }

        private void NNBtn_KolorLinii_Click(object sender, EventArgs e)
        {
            NNcolorkDialog_Linia.FullOpen = true;//Ustawienie koloru linii
            if (NNcolorkDialog_Linia.ShowDialog() == DialogResult.Cancel)
                return;
            NNTB_Kolor_linii.BackColor = NNcolorkDialog_Linia.Color;
            NNdrawline(); //rysowanie wziemniku linii
        }

        private void NNBTN_KolorTła_Click(object sender, EventArgs e)
        {
            NNcolordialog_tlo.FullOpen = true; //Ustawienie koloru tła
            if (NNcolordialog_tlo.ShowDialog() == DialogResult.Cancel)
                return;
            NNTB_kolor_Tla.BackColor = NNcolordialog_tlo.Color;
            NNdrawline();//rysowanie wziemniku linii
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            
        }

        void NNdrawline()
        {
            ////rysowanie wziemniku linii  przes picturebox'a
            Graphics NNg = NNPicturebox.CreateGraphics();
            NNg.Clear(NNTB_kolor_Tla.BackColor);
            int NNgrubosclinii;

            Color NNcolorlinii = NNTB_Kolor_linii.BackColor;

            NNgrubosclinii = Convert.ToInt32(NNlabel_grubosc.Text);

            Pen NNpen = new Pen(NNcolorlinii, NNgrubosclinii);

            switch (NNcomboBox_styl_linii.SelectedIndex)
            {
                case 0:
                    NNpen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
                    break;
                case 1:
                    NNpen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                    break;
                case 2:
                    NNpen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
                    break;
                case 3:
                    NNpen.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDot;
                    break;
            }

            NNg.DrawLine(NNpen, new Point(0, 13), new Point(100, 13));

        }

        private void NNtrackBar_grubosc_ValueChanged(object sender, EventArgs e)
        {
            //zmiana grubości linii oraz  rysowanie wziemniku linii po zmianie
            NNlabel_grubosc.Text = NNtrackBar_grubosc.Value.ToString();
            NNdrawline();
        }

        private void NNcomboBox_styl_linii_SelectedIndexChanged(object sender, EventArgs e)
        {
            NNdrawline();
        }

        private void Analiza_Load(object sender, EventArgs e)
        {
            NNdrawline();
        }

        private void Analiza_Shown(object sender, EventArgs e)
        {
            NNdrawline();
        }

        private void Analiza_Paint(object sender, PaintEventArgs e)
        {
            ////rysowanie wziemniku linii przy odtworzeniu formy
            NNdrawline();
        }






        private void NNBTN_wizualizacja_po_Click(object sender, EventArgs e)
        {
            //deklaracja kontrolki "Wizualizacja tablicy po sortowaniu"

            NNdgv_elementypo.Visible = true;
            NNdvgElementy.Visible = false;
            NNchart.Visible = false;
            NNBTN_graficzna.Enabled = true;
            NNBTN_wynniki_tabl.Enabled = true;
            NNdgv_Tabela_wynikow.Visible = false;
            NNBTN_do_sort.Enabled = true;
            NNBTN_wizualizacja_po.Enabled = false;
        }


        //Sprawdzanie liczb wprowadzonych użytkownikiem
        private void NNTB_minimalna_proba_badawcza_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(NNTB_minimalna_proba_badawcza.Text, out NNprobaBadawcza))
                errorProvider1.SetError(NNTB_minimalna_proba_badawcza, "ERROR: w podanej licznosci próby badawczej wystąpil niedozwolony znak");
        }

        private void NNTB_maks_rozmiar_tab_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(NNTB_maks_rozmiar_tab.Text, out NNMaxRozmiarTablicy))
                errorProvider1.SetError(NNTB_maks_rozmiar_tab, "ERROR: w podanej licznosci próby badawczej wystąpil niedozwolony znak");
        }

        private void NNTB_dolna_granica_TextChanged(object sender, EventArgs e)
        {
            if (!double.TryParse(NNTB_dolna_granica.Text, out NNDolnaGranicaWartosci))
                errorProvider1.SetError(NNTB_maks_rozmiar_tab, "ERROR: w podanej licznosci próby badawczej wystąpil niedozwolony znak");
        }

        private void NNTB_gorna_granica_TextChanged(object sender, EventArgs e)
        {
            if (!double.TryParse(NNTB_gorna_granica.Text, out NNGornagranicawartosci))
                errorProvider1.SetError(NNTB_maks_rozmiar_tab, "ERROR: w podanej licznosci próby badawczej wystąpil niedozwolony znak");
        }


        //Deklaracja Kontrolki Akceptacji
        private void NNBTN_AC_SORT_Click(object sender, EventArgs e)
        {
            //Deklaracja zmiennych
            NNWynikiZpomiaru = new float[NNMaxRozmiarTablicy];
            NNWynikiAnalityczne = new float[NNMaxRozmiarTablicy]; 
            float NNsummaOD, NNSredniaOD;
            NNsortowanie sort = new NNsortowanie(); // Tworzenie klassy sortowania
            int[] NNTablicaLOD = new int[NNprobaBadawcza];
            int NNLicznikOD=0;
            double[] NNtablica = new double[NNMaxRozmiarTablicy];
            double[] NNelementy = new double[NNMaxRozmiarTablicy];
            Random NNrdn = new Random();
            //Tworzymy tablicę i zapisujemy ją do DataGridView DO sortowania
            for (int i = 0; i < NNMaxRozmiarTablicy; i++)
            {
                NNtablica[i] = NNrdn.NextDouble() * (NNGornagranicawartosci - NNDolnaGranicaWartosci) + NNDolnaGranicaWartosci;
                NNelementy[i] = NNtablica[i];
                NNdvgElementy.Rows.Add();
                NNdvgElementy.Rows[i].Cells[0].Value = i;
                NNdvgElementy.Rows[i].Cells[1].Value = String.Format("{0, 8:F3}", NNelementy[i]);
                
            }

            //Sortowanie tablicy o podanym MAX rozmiarze Tablicy
            switch (NNcombobox_algorytm.SelectedIndex)
            {
                case 0:
                    NNLicznikOD = sort.NNInsertionSort(ref NNtablica, NNMaxRozmiarTablicy);
                    break;
                case 1:
                    NNLicznikOD = sort.NNHeapSort(ref NNtablica, NNMaxRozmiarTablicy);
                    break;
                case 2:
                    NNLicznikOD = sort.NNQuickSortRecursive(ref NNtablica, 0, NNMaxRozmiarTablicy  - 1);
                    break;
                case 3:
                    NNLicznikOD = sort.NNIntroSort(ref NNtablica, NNMaxRozmiarTablicy);
                    break;
            }
            //Zapisujemy Sortowaną tablicę do innego DataGridView, Żeby użytkownik mog zobaczycz że program Sortue poprawnie.
            for (int i = 0; i < NNMaxRozmiarTablicy; i++)
            {
                NNdgv_elementypo.Rows.Add();
                NNdgv_elementypo.Rows[i].Cells[0].Value = i;
                NNdgv_elementypo.Rows[i].Cells[1].Value = String.Format("{0, 8:F3}", NNtablica[i]);
            }


            //Deklaracja Kontrolki Akceptacji
            /////////////////////////////////
            NNBTN_do_sort.Enabled = true;
            NNBTN_wizualizacja_po.Enabled = true;
            NNBTN_AC_SORT.Enabled = false;
            NNBTN_wynniki_tabl.Enabled = true;
            NNBTN_graficzna.Enabled = true;
            NNcombobox_algorytm.Enabled = false;
            /////////////////////////////////
            

            //Liczymy Licznik OD dla każdej tablicy
            for (int k = 1; k < NNMaxRozmiarTablicy; k++)
            {
                //Ile razy biędzie program wykonywać sortowanie
                for (int i = 0; i < NNprobaBadawcza; i++)
                {
                    //Tworzymy nową tablicę dla każdego sortowania
                    for (int l = 0; l < NNMaxRozmiarTablicy; l++)
                    {
                        NNtablica[l] = NNrdn.NextDouble() * (NNGornagranicawartosci - NNDolnaGranicaWartosci) + NNDolnaGranicaWartosci;
                    }
                    //Liczymy OD oraz s sortowanie
                    switch (NNcombobox_algorytm.SelectedIndex)
                    {
                        case 0:
                            NNLicznikOD = sort.NNInsertionSort(ref NNtablica, k); //Insertion Sort
                            break;
                        case 1:
                            NNLicznikOD = sort.NNHeapSort(ref NNtablica, k); //Heap Sort
                            break;
                        case 2:
                            NNLicznikOD = sort.NNQuickSortRecursive(ref NNtablica, 0, k); //QuikSort
                            break;
                        case 3:
                            NNLicznikOD = sort.NNIntroSort(ref NNtablica, k); //IntroSort
                            break;


                    }
                    NNTablicaLOD[i] = NNLicznikOD; //zapamientamy Licznik OD
                }
                //Sumujemy liczniki OD i znajdujem srednią to jest nasz wynik z pomiaru
                NNsummaOD = 0.0F;
                for (int j = 0; j < NNprobaBadawcza; j++)
                    NNsummaOD = NNsummaOD + NNTablicaLOD[j];
                NNSredniaOD = NNsummaOD / NNprobaBadawcza;
                //zapisujemy do tablicy gdy k = rozmiar sortowanej tablicy
                NNWynikiZpomiaru[k] = NNSredniaOD;

                
                switch (NNcombobox_algorytm.SelectedIndex)
                {
                    case 0:
                        NNWynikiAnalityczne[k] = k * (k - 1) / 2; //Analityczy koszt czasu dla sortowanie IsertSort
                        break;
                    case 1:
                        NNWynikiAnalityczne[k] = Convert.ToSingle(k*Math.Log(k));//Analityczy koszt czasu dla sortowania HeapSort k*log(k)

                        break;
                    case 2:
                        NNWynikiAnalityczne[k] = Convert.ToSingle(k * Math.Log(k+1,2));//Analityczy koszt czasu dla sortowania QuikSort k*log_2(k+1)
                        break;
                    case 3:
                        NNWynikiAnalityczne[k] = Convert.ToSingle(k * Math.Log(k,2));//Analityczy koszt czasu dla sortowania Introsort k*log(k)
                        break;
                 }




            }
            
        }

        //Tworzymy klasę sortowanie
        class NNsortowanie
        {
            int NNLicznikOD = 0;
            
            public int NNInsertionSort(ref double[] T, int n)
            {
                int NNLicznikOD = 0;
                double NNkopiaElem;
                //Wstawieanie elementów z podtablicy nieuporządkowanej do uporządkowanej
                int k;
                for (int i = 1; i < n; i++)
                {//Niezmiennik oblicień: T[0]<= T[1]<= ...<=T[i-1]
                    NNkopiaElem = T[i];//
                    k = i;
                    //Szukamy miejsca dla Kopii Elementu w tablice uporząkowanej
                    while((k>0)&&(NNkopiaElem < T[k-1]))
                    {
                        NNLicznikOD++;//Licznik OD plusujemy kiedy mamy OD operację dominującą
                        // np. NNkopiaElem < T[k-1] w "while"
                        T[k] = T[k - 1];
                        k--;
                    }

                    if (k > 0)
                        NNLicznikOD++;
                    //Operacja dominująca dla wyjścia z while LicznikOD ++
                    //Elementy tablicy zostały przesunięte o jędnąpozycję w prawo
                    //Do zwolnego miejsca T[k] wstawiamy Kopie Elementu "NNkopiaElem"
                    T[k] = NNkopiaElem;
                    //Niezmiennik obliczeń T[0]<= T[1]<= ...<=T[i]
                }
                //Niezmiennik obliczeń T[0]<= T[1]<= ...<=T[i-1]
                // co oznacza koniec sortowania


                return NNLicznikOD;
                //zwracamy licznikOD
            }
            public int NNHeapSort(ref double[] T, int n)
            {
                //dodatkowe zmienne pomocnicze
                
                int NNlicznik = 0;
                //tworzymy drzewo z tablicy
                for (int p = (n - 1) / 2; p >= 0; --p)
                    // elementy drzewa opracujemy przes NNMaxHeapify gdy szukamy maks element w drzewie
                    NNlicznik = NNlicznik  + NNMaxHeapify(ref T, n, p);
                
                for (int i = T.Length - 1; i > 0; --i)
                {   //Rewersujemy nasze drzewo
                    double NNtemp = T[i];
                    T[i] = T[0];
                    T[0] = NNtemp;
                    //zmienszamy granicę tablicy na 1 
                    --n;
                    //powtarzamy dla mniejszego rewersowanego drzewa funkcje szukania największego elementa
                    NNlicznik = NNlicznik  +NNMaxHeapify(ref T, n, 0);
                }
                //zwracamy LicznikOD
                return NNlicznik;
            }

            int  NNMaxHeapify(ref double[] T, int n, int NNindex)
            {
                int NNLicznikOD = 0;
                //liczymy index dla następnych elmentów drzewa
                int NNleft = (NNindex + 1) * 2 - 1;
                int NNright = (NNindex + 1) * 2;
                
                int NNlargest = 0;
                //Jeśli mamy jeszcie mejsce z lewej strony:
                if (NNleft < n)
                    //Jesli element z lewej strony > Elementa o indexu podanego  do Funkcji (T[p])
                    if (T[NNleft] > T[NNindex])
                    { 
                     
                    NNlargest = NNleft;
                    NNLicznikOD++;
                    }
                    else
                        NNlargest = NNindex;
                else
                    NNlargest = NNindex;
                //jesli element T[p] >  elementu z lewej strony od niego zmieniamy ich miejsca



                //sprawdzamy czy prawy element jest wiekszy niz T[p] albo od T[NNleft](w zalieżności co mamy krok temu)
                if (NNright < n)
                    if (T[NNright] > T[NNlargest])
                    {
                        NNlargest = NNright;
                        NNLicznikOD++;
                    }


                //jeśli T[p] nie najwiekszy z 3 elementów (T[p], element z lewej, element z prawej)
                if (NNlargest != NNindex)
                {// wtedy zmieniamy ich wartość już w tablice
                    double NNtemp = T[NNindex];
                    T[NNindex] = T[NNlargest];
                    T[NNlargest] = NNtemp;
                    //liczymy Licznik OD
                    //Powtarzamy dla najwekszego elementa Jesli nie T[p]! dopóki nie biędzie nasz element największym w drzewie
                    NNLicznikOD = NNLicznikOD + NNMaxHeapify(ref T, n, NNlargest);
                }
                return NNLicznikOD;
               
               
            }

            public int NNQuickSortRecursive(ref double[] T, int NNleft, int NNright)
            {
                int NNLicznikOD = 0;
                double NNkopia;//element tablicy z którym pracujemy chwilowo
                int NNi = NNleft;
                int NNj = NNright;
                double NNx = T[(NNleft+NNright) / 2]; //wybieramy element tablicy 

                do
                {
                    while (T[NNi] < NNx)/*sprawdzamy elementy dopóki znajdziemy ten który większy niz wybrany element
                    sprawdzamy z lewa*/
                    { NNi++; NNLicznikOD++; }
                    NNLicznikOD++;
                    while (T[NNj] > NNx)/*sprawdzamy elementy dopóki znajdziemy ten który mniejszy niz wybrany element
                    sprawdzamy z prawa*/
                    { NNj--; NNLicznikOD++; }
                    NNLicznikOD++;
                    //wymieniamy elementy tablicy między pozicją NNi i NNj
                    if (NNi <= NNj)
                    {
                        NNkopia = T[NNi];
                        T[NNi] = T[NNj];
                        T[NNj] = NNkopia;
                        //zmieniamy i wpisujemy nasz T[NNi](NNkopia) do wolnego mejsca

                        NNi++; NNj--; //uaktualnienie indeksów dla naszych while
                    }

                } while (NNi <= NNj);

                //rekurencyjne wypielniamy dla podtablic
                if (NNleft < NNj)
                    NNLicznikOD = NNLicznikOD + NNQuickSortRecursive(ref T, NNleft, NNj);
                if (NNright > NNi)
                    NNLicznikOD = NNLicznikOD + NNQuickSortRecursive(ref T, NNi, NNright);
                return NNLicznikOD;


                

            }
            //funkcjonalność dla metody  Introsort
            //potrzebujemy znależć mediany  z 3
            
           
            int NNPartition(ref double[] T, int NNleft, int NNright)//podajemy granicy Tablicy albo podtablicy
            {
                
                double NNpv = T[NNright];//zmienna robocza
                double NNtemp;
                int NNi = NNleft;//lewa granica jako NNi

                for (int j = NNleft; j < NNright; ++j)//od lewej do prawej granicy
                {
                    //sprawdzamy czy elementy są mniejsze od wybranego z końca tablicy
                    if (T[j] <= NNpv)
                    {
                        
                        //ten element z tym który jest na początku tablicy
                        NNtemp = T[j];
                        T[j] = T[NNi];
                        T[NNi] = NNtemp;
                        //to znaczy że element z lewa już przerobiliśmy i zwiekszamy NNi (lewa granica tablicy)          
                        NNi++;
                    }
                }
                //element medialny
                T[NNright] = T[NNi];
                T[NNi] = NNpv;
                //zwracamy id Mediany dla rozdzielenia tablicy 
                return NNi;
                
            }
            public int NNIntroSort(ref double[] T , int n)
            {
                int NNLicznik = 0;
                int NNdzSize = NNPartition(ref T, 0, n - 1);
                //znajdziemy id mediane oraz punkt o którym podzielimy tablicę
                
                if (NNdzSize < 16)
                {
                    //przy <16 elementach uzywamy Insertionsort
                    NNLicznik = NNLicznik + NNInsertionSort(ref T, n);
                }
                
                else 
                {  
                    
                    if (NNdzSize > (2 * Math.Log(n)))
                        //przy index'e mediany > od glębokości rekurencji używamy HeapSort
                        NNLicznik = NNLicznik + NNHeapSort(ref T, n);
                    else
                    {//gdy ilość elementów podtablicy >15 i glębokość rekurencji > naszego dzielnika NNdzSize używamy QuikSort
                       NNLicznik = NNLicznik + NNQuickSortRecursive(ref T, 0, n);
                    }
                }
                return NNLicznik;
            }






        }
        //prosta rekurencja dla liczenia pamięci dla algorytmu QuikSort
        int NNreksum(int i)
        {
            if (i == 1)
            {
                return 1;
            }
            else
            {
                return i + NNreksum(i - 1);
            }
        }

        //tabelaryczne wyniki 
        private void NNBTN_wynniki_tabl_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= NNMaxRozmiarTablicy; i++)
            {
                //dodajemy danne do tabeli z tablic wynników z pomiaru oraz analityczne wyniki, oraz i jako rozmiar tablicy
                NNdgv_Tabela_wynikow.Rows.Add();
                NNdgv_Tabela_wynikow.Rows[i-1].Cells[0].Value = i;
                NNdgv_Tabela_wynikow.Rows[i - 1].Cells[1].Value = String.Format("{0, 0:F2}", NNWynikiZpomiaru[i-1]);
                NNdgv_Tabela_wynikow.Rows[i - 1].Cells[2].Value = String.Format("{0, 0:F2}", NNWynikiAnalityczne[i-1]);
                //Pamięć potrzebna dla sortowania
                switch (NNcombobox_algorytm.SelectedIndex)
                {
                    case 0:
                        NNdgv_Tabela_wynikow.Rows[i - 1].Cells[3].Value = i + 1;
                        break;
                    case 1:
                        NNdgv_Tabela_wynikow.Rows[i - 1].Cells[3].Value = 1;
                        break;
                    case 2:
                        
                        NNdgv_Tabela_wynikow.Rows[i - 1].Cells[3].Value = NNreksum(i);
                        break;
                    case 3:
                        NNdgv_Tabela_wynikow.Rows[i - 1].Cells[3].Value = i + 1;
                        break;
                }
                
            }

            //obsługa kontrolki
            //////////////////////////////////
            NNdgv_Tabela_wynikow.Visible = true;
            NNBTN_wynniki_tabl.Enabled = false;
            NNdvgElementy.Visible = false;
            NNdgv_elementypo.Visible = false;
            NNchart.Visible = false;
            NNBTN_wizualizacja_po.Enabled = true;
            NNBTN_graficzna.Enabled = true;
            NNBTN_do_sort.Enabled = true;
            //////////////////////////////////
        }

        private void NNcombobox_algorytm_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        //Obsługa kontrolki graficznej prezentacji obliczeń

        private void NNBTN_graficzna_Click(object sender, EventArgs e)
        {
            
            NNchart.Series.Clear();
            NNchart.Titles.Clear();
            //Tworzenie nazwę wykresu 
            NNchart.Titles.Add("Algorytm  " + NNcombobox_algorytm.SelectedItem);
            //kolor tła wybrany użytkownikiem
            NNchart.BackColor = NNTB_kolor_Tla.BackColor;
            NNchart.Legends["Legend1"].Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            int[] NNrozmiartabeli = new int[NNMaxRozmiarTablicy];
            //dodatkowa tablica rozmiarów tablic
            for (int i = 0; i < NNMaxRozmiarTablicy; i++)
                NNrozmiartabeli[i] = i;
            //rysujemy 1 graph
            NNchart.Series.Add("Koszt czasowy z pomiaru"); ;
            NNchart.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            NNchart.Series[0].Color = NNTB_Kolor_linii.BackColor;
            NNchart.ChartAreas["ChartArea1"].BackColor = NNTB_kolor_Tla.BackColor ;
            //stył linii zwybrany użytkownikiem
            switch (NNcomboBox_styl_linii.SelectedIndex)
            {
                case 0:
                    NNchart.Series[0].BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
                    break;
                case 1:
                    NNchart.Series[0].BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash; break;
                case 2:

                    NNchart.Series[0].BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dot; break;
                case 3:
                    NNchart.Series[0].BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.DashDot; break;
            }
            //grubość linii
            NNchart.Series[0].BorderWidth = Convert.ToInt32(NNlabel_grubosc.Text);
            NNchart.Visible = true;
            //dodajemy punkty obliczeń OD
            for (int i = 0; i < NNMaxRozmiarTablicy; i++)
            {
                NNchart.Series[0].Points.AddXY(NNrozmiartabeli[i], NNWynikiZpomiaru[i]);
            }
            //Anologicznie dodajemy punkty anolitycznego pomiaru
            NNchart.Series.Add("Koszt Analityczny");
            NNchart.Series[1].Name = "Analityczny koszt";
            NNchart.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            NNchart.Series[1].Color = Color.Red; ;
            NNchart.Series[1].BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash;
            
            for (int i = 0; i < NNMaxRozmiarTablicy; i++)
            {
                NNchart.Series[1].Points.AddXY(NNrozmiartabeli[i], NNWynikiAnalityczne[i]);
            }
            //Anologiczne dla kosztu pamięci
            NNchart.Series.Add("Koszt Pamienciowy");
            NNchart.Series[2].Name = "Koszt Pamienciowy";
            NNchart.Series[2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            NNchart.Series[2].Color = Color.Blue; ;
            NNchart.Series[2].BorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            
            //Koszt pamięci zgodnie z wybranym algorytmem
            for (int i = 0; i < NNMaxRozmiarTablicy; i++)
            {
                
                switch(NNcombobox_algorytm.SelectedIndex)
                {
                    case 0:
                        NNchart.Series[2].Points.AddXY(i,i + 1);
                    break;
                    case 1:
                        NNchart.Series[2].Points.AddXY(i,1);
                    break;
                    case 2:

                        NNchart.Series[2].Points.AddXY(i,NNreksum(i));
                    break;
                    case 3:
                        NNchart.Series[2].Points.AddXY(i,i + 1);
                    break;
                }
            }
            //////////////////////
            NNBTN_graficzna.Enabled = false;
            NNBTN_wynniki_tabl.Enabled = true;
            NNdgv_Tabela_wynikow.Visible = false;
            NNdvgElementy.Visible = false;
            NNdgv_elementypo.Visible = false;
            //////////////////////


        }

        private void NNBTN_do_sort_Click(object sender, EventArgs e)
        {
            //obsługa kontrolki do sortowania oraz ją odświetlenie
            NNdvgElementy.Visible = true;
            NNdgv_elementypo.Visible = false;
            NNchart.Visible = false;
            NNBTN_graficzna.Enabled = true;
            NNBTN_wynniki_tabl.Enabled = true;
            NNdgv_Tabela_wynikow.Visible = false;
            NNBTN_do_sort.Enabled = false;
            NNBTN_wizualizacja_po.Enabled = true;
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            //obsługa kontrolki RESET
            NNchart.Series.Clear();
            NNdvgElementy.Rows.Clear();
            NNdgv_Tabela_wynikow.Rows.Clear();
            NNdgv_elementypo.Rows.Clear();

            NNBTN_AC_SORT.Enabled = true;
            NNBTN_graficzna.Enabled = true;
            NNBTN_wynniki_tabl.Enabled = true;
            NNBTN_do_sort.Enabled = true;
            NNBTN_wizualizacja_po.Enabled = true;

            NNchart.Visible = false;
            NNdvgElementy.Visible = false;
            NNdgv_Tabela_wynikow.Visible = false;
            NNdgv_elementypo.Visible = false;

            NNcombobox_algorytm.Enabled = true;
        }

        //SPrawdzian

        //deklaracja struct
        public struct EwidencjaBiblioteczna
        {
            public int NNsygnatura;
            public string NNtytul;
            public string NNautor;
            public string NNrokWydania;
            public int NNdlasort;//dodatkowy rekord dla sortowania

        };
        //lista z rekordów
        EwidencjaBiblioteczna[] NNlsita = new EwidencjaBiblioteczna[5];
        
        private void BTN_Click(object sender, EventArgs e)
        {//wprowadzam dane
            NNlsita[0].NNsygnatura = 1;
            NNlsita[0].NNtytul = "Wojna";
            NNlsita[0].NNautor = "Piotr" ;
            NNlsita[0].NNrokWydania = "20.05.1957";

            NNlsita[1].NNsygnatura = 2;
            NNlsita[1].NNtytul = "Twarz";
            NNlsita[1].NNautor = "Semir";
            NNlsita[1].NNrokWydania = "02.11.1990";

            NNlsita[2].NNsygnatura = 3;
            NNlsita[2].NNtytul = "Swiatlo";
            NNlsita[2].NNautor = "Dmytro";
            NNlsita[2].NNrokWydania = "13.04.2000";

            NNlsita[3].NNsygnatura = 4;
            NNlsita[3].NNtytul = "Doloto";
            NNlsita[3].NNautor = "Emilia";
            NNlsita[3].NNrokWydania = "12.08.1931";

            NNlsita[4].NNsygnatura = 5;
            NNlsita[4].NNtytul = "Król";
            NNlsita[4].NNautor = "Kerus";
            NNlsita[4].NNrokWydania = "09.10.1892";
            //dodaję do tabeli "NNtabSpr" do sortowania
            for (int i = 0; i<5; i++)
            {
                NNtabSpr.Rows.Add();
                NNtabSpr.Rows[i].Cells[0].Value = (Convert.ToString(NNlsita[i].NNsygnatura));
                NNtabSpr.Rows[i].Cells[1].Value = (Convert.ToString(NNlsita[i].NNtytul));
                NNtabSpr.Rows[i].Cells[2].Value = (Convert.ToString(NNlsita[i].NNautor));
                NNtabSpr.Rows[i].Cells[3].Value = (Convert.ToString(NNlsita[i].NNrokWydania));
                NNtabSpr.Visible = true;
            }
            //obsluga kontrolki
            NNBTNposort.Enabled = true;
            NNtapSPR_po_sort.Visible = false;
        }

        //obsluga kontrolki po sortowaniu
        private void NNBTNposort_Click(object sender, EventArgs e)
        {
            string NNstr1;
            char[] NNalpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
           
            double[] NNTabelaDlaSortowania = new double[5];//tabela którą biędziemy sortować
            for (int k = 0; k < 5; k++)//dla każdego rekorda
                for (int i = 0; i < 26; i++)//dla kazdej litery
                    {  NNstr1 = NNlsita[k].NNtytul;//NNStr1 = Tytul Książki
                    if (NNalpha[i] == NNstr1[0])//Jeśli litera alphabetu równa 1 litere tytulu
                    {
                        NNTabelaDlaSortowania[k] = i; //dajemy jej liczbę od 0 do 26 
                        NNlsita[k].NNdlasort = i;//danne rekordów jaką 1 liczbę mają ich tytuly
                    }
                    }
            NNsortowanie sort = new NNsortowanie();//sortowanie intersort
            sort.NNInsertionSort(ref NNTabelaDlaSortowania, 5);

            //sprawdzamy sortowane liczby z Liczbami z rekordów i jeśli równe wpisujemy do tabeli po sortowaniu
            for (int k = 0; k < 5; k++)
                for (int i = 0; i < 5; i++)
                {
                   if (NNTabelaDlaSortowania[k] == NNlsita[i].NNdlasort)
                    {
                        NNtapSPR_po_sort.Rows.Add();
                        NNtapSPR_po_sort.Rows[k].Cells[0].Value = (Convert.ToString(NNlsita[i].NNsygnatura));
                        NNtapSPR_po_sort.Rows[k].Cells[1].Value = (Convert.ToString(NNlsita[i].NNtytul));
                        NNtapSPR_po_sort.Rows[k].Cells[2].Value = (Convert.ToString(NNlsita[i].NNautor));
                        NNtapSPR_po_sort.Rows[k].Cells[3].Value = (Convert.ToString(NNlsita[i].NNrokWydania));
                        NNtapSPR_po_sort.Visible = true;
                    }

                }


            NNBTNposort.Enabled = false;
            BTN.Enabled = true;
            NNtabSpr.Visible = false;
        }
    }
}

