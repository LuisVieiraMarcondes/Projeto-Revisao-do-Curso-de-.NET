using System;

namespace Revisao
{
    class Program
    {
        static void Main(string[] args)
        {   
            Aluno[] alunos = new Aluno[5];
            var indiceAluno = 0;
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X") //mesmo se o usuario utiliza letra minuscula vai haver tratamento da string
            {
                switch (opcaoUsuario)
                {

                    case "1":
                        Console.WriteLine("Informe o nome do Aluno:");
                        Aluno aluno = new Aluno();
                        aluno.Nome = Console.ReadLine();

                        Console.WriteLine("Informe a nota do Aluno:");

                        if ( decimal.TryParse(Console.ReadLine(), out decimal nota ))
                        {
                            aluno.Nota = nota ;
                        }
                        else
                        {
                            throw new ArgumentOutOfRangeException("Valor da nota deve ser decimal");
                        }

                        alunos[indiceAluno] = aluno;
                        indiceAluno++; //incrementa para que o proximo aluno ele já vá pra próxima casa no array;

                        break;

                    case "2":
                        foreach(var a in alunos)
                        {
                            if(!string.IsNullOrEmpty(a.Nome))
                            {                            
                            Console.WriteLine($"ALUNO: {a.Nome} - NOTA: {a.Nota}");     //usando o objeto "a" pra cada aluno imprime o nome do aluno e a nota
                            }

                        }
                        
                        break;

                    case "3":
                        decimal notaTotal = 0;
                        var nrALunos = 0;
                        
                        for (int i= 0; i < alunos.Length; i++)
                        {
                            if(!string.IsNullOrEmpty(alunos[i].Nome))
                            {
                                notaTotal = notaTotal + alunos[i].Nota;
                                nrALunos++;
                            }
                        } 

                            var mediaGeral = notaTotal / nrALunos;

                            ConceitoEnum conceitoGeral;

                            if(mediaGeral <= 2)
                            {
                                conceitoGeral = ConceitoEnum.E;
                            }
                            else if(mediaGeral <= 4)
                            {
                                conceitoGeral = ConceitoEnum.D;
                            }
                            else if(mediaGeral <= 6)
                            {
                                conceitoGeral = ConceitoEnum.C;
                            }
                            else if(mediaGeral <= 8)
                            {
                                conceitoGeral = ConceitoEnum.B;
                            }
                            else
                            {
                                conceitoGeral = ConceitoEnum.A;
                            }


                            Console.WriteLine($"MÉDIA GERAL: {mediaGeral} - CONCEITO {conceitoGeral}");


                        break;

                    default:

                        throw new ArgumentOutOfRangeException(); //Vai disparar uma excesao está fora do range de opçoes.

                }

            
                opcaoUsuario = ObterOpcaoUsuario();

            }
        }

        private static string ObterOpcaoUsuario()
        {   
            Console.WriteLine("===========================");
            Console.WriteLine("Informe a Opção desejada: ");
            Console.WriteLine("1 - Inserir novo Aluno");
            Console.WriteLine("2 - Listar Alunos");
            Console.WriteLine("3 - Calcular média geral");
            Console.WriteLine("X - Sair");
            Console.WriteLine();


            string opcaoUsuario = Console.ReadLine();
            return opcaoUsuario;
        }
    }
}
