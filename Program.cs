using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exa1ConsolaTablas
{
    class Program
    {
        struct tipo
        {
            public int num;
            public int nota1;
            public int nota2;
            public int nota3;
            public int suma;
        };

        const int N = 4;

        static void Main(string[] args)
        {
            tipo[] tab1 = new tipo[N];
            tipo[] tab2 = new tipo[N];
            int op = 0;
            do
            {
                op = menu();
                switch (op)
                {
                    case 1:
                        altas(tab1, 1);
                        break;
                    case 2:
                        altas(tab2, 2);
                        break;
                    case 3:
                        listado(tab1, tab2);
                        break;
                    case 4:
                        proceso(tab1, tab2);
                        break;
                    case 0:
                        Console.Write("Pulse cualquier tecla para salir...");
                        Console.ReadKey(true);
                        break;
                }

            } while (op != 0);
        }

        static int menu()
        {
            int op = 0;
            bool correcto = false;
            while (correcto == false)
            {
                Console.Clear();
                Console.Write("1. Altas tab1");
                Console.Write("\n2. Altas tab2");
                Console.Write("\n3. Listado las dos");
                Console.Write("\n4. Proceso");
                Console.Write("\n0. Salir");
                Console.Write("\nOpción: ");
                correcto = Int32.TryParse(Console.ReadLine(), out op);
            }
            return (op);
        }

        static void altas(tipo[] tab, int v)                       //Funcion para altas
        {
            int paso = 1;
            if (v == 2)
                paso = 2;
            for (int i = 1, j = 0; j < N; j++, i++)
            {
                tab[j].num = i;
                tab[j].nota1 = i * 2 * paso;
                tab[j].nota2 = i * 2 * paso;
                tab[j].nota3 = i * 2 * paso;
                tab[j].suma = i * 6 * paso;
            }
        }

        static void listado(tipo[] tab1, tipo[] tab2)
        {
            Console.Write("\nTabla 1");
            Console.Write("\n\tNúmero \tNota1 \tNota2 \tNota3 \tSuma");
            Console.Write("\n\t-------------------------------------\n");
            for (int i = 0; i < N; i++)
            {
                Console.WriteLine("\t{0} \t{1} \t{2} \t{3} \t{4}", tab1[i].num, tab1[i].nota1, tab1[i].nota2, tab1[i].nota3, tab1[i].suma);
            }

            Console.Write("\nTabla 2");
            Console.Write("\n\tNúmero \tNota1 \tNota2 \tNota3 \tSuma");
            Console.Write("\n\t-------------------------------------\n");
            for (int i = 0; i < N; i++)
            {
                Console.WriteLine("\t{0} \t{1} \t{2} \t{3} \t{4}", tab2[i].num, tab2[i].nota1, tab2[i].nota2, tab2[i].nota3, tab2[i].suma);
            }
            Console.Write("\nIntroduzca una tecla para continuar");
            Console.ReadKey(true);
        }

        static void proceso(tipo[] tab1, tipo[] tab2)
        {
            int suma = 0;
            int posi1 = 0, posi2 = 0;
            bool correcto = false;
            while (correcto == false)
            {
                Console.Write("\n\nIntroduzca valor de suma a buscar: ");
                correcto = Int32.TryParse(Console.ReadLine(), out suma);
            }
            posi1 = busca(tab1, suma);
            posi2 = busca(tab2, suma);
            if (posi1 != -1 && posi2 != -1)
            {
                tab1[posi1].suma = 0;
                tab2[posi2].suma = 0;
            }
        }

        static int busca(tipo[] tab, int valor)
        {
            int i = 0;
            for (i = 0; i < N; i++)
            {
                if (tab[i].suma == valor)
                {
                    return (i);
                }
            }
            return (-1);
        }
    }
}
