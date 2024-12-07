namespace AOC2024.Day7;

public class Problem1() : Day(7)
{
    public override void Run()
    {
        var lines = Utils.ReadInputLines(GetInputPath());
        var equations = lines
            .Select(l =>
            {
                var splits = l.Split(':');
                var expectedValue = double.Parse(splits[0]);
                var terms = splits[1].Trim().Split(" ").Select(int.Parse).ToList();
                return new Equation(expectedValue, terms);
            });
        var result = equations
            .Where(eq => IsEquationValid(eq, 3))
            .Sum(eq => eq.ExpectedValue);
        
        Console.WriteLine(result);
    }

    private bool IsEquationValid(Equation equation, int basis)
    {
        // if the equation has n terms, that means that there should be n - 1 operators
        // since there are basis possible operators, any possible combination of operators
        // can be represented as an n-1 digit number in base basis,
        // where 0 represents addition, 1 represents multiplication, 2 represents concatenation.
        // more operations can be defined. 
        foreach (var operatorRepresentation in Enumerable.Range(0, (int)Math.Pow(basis, equation.Terms.Count - 1)))
        {
            double sum = equation.Terms.First();
            var opps = operatorRepresentation;
            for (var i = 1; i < equation.Terms.Count; i++)
            {
                var term = equation.Terms[i];
                if (opps % basis == 0)
                {
                    sum += term;
                }
                else if (opps % basis == 1)
                {
                    sum *= term;
                }
                else
                {
                    var joined = sum + term.ToString();
                    sum = double.Parse(joined);
                }

                opps /= basis;
            }

            // ReSharper disable once CompareOfFloatsByEqualityOperator
            if (sum == equation.ExpectedValue)
            {
                return true;
            }
        }

        return false;
    }
    
    record Equation(double ExpectedValue, List<int> Terms);
}