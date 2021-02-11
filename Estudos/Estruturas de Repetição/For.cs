using System;
class loopFor 
{
  static void Main() 
  {
    /* Ultilizado quando sabemos a quantidade
    de repetições que um bloco deve fazer! */
    
    /* Enquanto a condição do contador for True o bloco
    será executado:
    contador = 0  
    condição = contador menor que 5? Contador deve ser menor que 5!!
    iterador = adiciona 1 */
    
    // Exemplo de uso:
    for(int contador = 0; contador < 5; contador++)
    {
      Console.WriteLine(contador);  
    }
    
    // Outro Exemplo de uso:
    for (int contador = 0; contador < 5; Console.WriteLine(contador), contador++){}
  }
}