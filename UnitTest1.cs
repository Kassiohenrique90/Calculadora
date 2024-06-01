using System.Security.Cryptography.X509Certificates;
using NuGet.Frameworks;

namespace Calculadora;

public class UnitTest1
{

    public BaseCalculadora construirBase()
    {
        string data = "01/06/2024";
        BaseCalculadora calc = new BaseCalculadora("01/06/2024");
        return calc;
    }

    [Theory]
    [InlineData (1, 2, 3)]
    [InlineData (4, 5, 9)]
    public void TesteSomar(int valor1, int valor2, int resultado)
    {
        BaseCalculadora calc = construirBase();

        int resultadoCalculadora = calc.somar(valor1, valor2);

        Assert.Equal(resultado, resultadoCalculadora);
    }

    [Theory]
    [InlineData (2, 2, 4)]
    [InlineData (5, 2, 10)]
    public void TesteMultiplicar(int valor1, int valor2, int resultado)
    {
        BaseCalculadora calc = construirBase();

        int resultadoCalculadora = calc.multiplicar(valor1, valor2);

        Assert.Equal(resultado, resultadoCalculadora); 
    }

    [Theory]
    [InlineData (6, 2, 3)]
    [InlineData (5, 5, 1)]
    public void TesteDividir(int valor1, int valor2, int resultado)
    {
        BaseCalculadora calc = construirBase();

        int resultadoCalculadora = calc.dividir(valor1, valor2);

        Assert.Equal(resultado, resultadoCalculadora); 
    }

    [Theory]
    [InlineData (6, 2, 4)]
    [InlineData (5, 5, 0)]
    public void TesteSubtrair(int valor1, int valor2, int resultado)
    {
        BaseCalculadora calc = construirbase();

        int resultadoCalculadora = calc.subtrair(valor1, valor2);

        Assert.Equal(resultado, resultadoCalculadora); 
    }

    public void TestarDivisaoPorZero()
    {
        BaseCalculadora calc = construirBase();

        Assert.Throws<DivideByZeroException>(() => calc.dividir(3,0));

    }

     public void TestarHistorico()
    {
        BaseCalculadora calc = construirBase();

        calc.somar(1, 2);
        calc.somar(2, 8);
        calc.somar(3, 7);
        calc.somar(4, 1);

        var lista = calc.historico();

        Assert.NotEmpty(lista); 
        Assert.Equal(3, lista.Count);

    }   
}   
