using Microsoft.AspNetCore.Components;

namespace BlazorApp7.Pages 
{
    public partial class Calculator : ComponentBase
    {
        protected double tal1;
        protected double tal2;

        protected string? resultatText;
        protected string? fejl;

        protected void Add()
        {
            Clear();
            resultatText = (tal1 + tal2).ToString();
        }

        protected void Clear()
        {
            resultatText = null;
            fejl = null;
        }
        protected void Subtract()
        {
            Clear();
            resultatText = (tal1 - tal2).ToString();
        }

        protected void Multiply()
        {
            Clear();
            resultatText = (tal1 * tal2).ToString();
        }

        protected void Divide()
        {
            Clear();
            if (tal2 == 0)
            {
                fejl = "Kan ikke dividere med 0.";
                return;
            }
            resultatText = (tal1 / tal2).ToString();
        }

        protected void Factorial()
        {
            Clear();

            if (tal1 < 0)
            {
                fejl = "Fakultet er kun defineret for ikke-negative heltal.";
                return;
            }

            long n = (long)Math.Floor(tal1);
            if (Math.Abs(tal1 - n) > double.Epsilon)
                fejl = $"Runder tal1 ned til {n} for fakultet."; // informativt

            if (n > 20)
            {
                fejl = (fejl is null ? "" : fejl + " ") + "Vælg et tal ≤ 20.";
                return;
            }

            long res = Fakultet(n);
            resultatText = res.ToString();

            tal1 = res;          // nu bliver næste "!" = (res)!
            StateHasChanged();   // opdater inputfeltet på skærmen
        }


        private long Fakultet(long n)
        {
            long acc = 1;
            for (long i = 2; i <= n; i++)
                acc *= i;
            return acc;
        }

    }
}