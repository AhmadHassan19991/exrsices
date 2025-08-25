public static class SimpleCalculator
{
    public static string Calculate(int operand1, int operand2, string? operation)
    {
        // خطوة 1: فحص null وفارغ
        if (operation == null)
        {
            throw new ArgumentNullException(nameof(operation));
        }
        if (operation == "")
        {
            throw new ArgumentException("Operation cannot be empty", nameof(operation));
        }

        // خطوة 2: التحقق من العمليات وتنفيذها
        switch (operation)
        {
            case "+":
                return $"{operand1} + {operand2} = {operand1 + operand2}";

            case "*":
                return $"{operand1} * {operand2} = {operand1 * operand2}";

            case "/":
                if (operand2 == 0)
                    return "Division by zero is not allowed.";
                return $"{operand1} / {operand2} = {operand1 / operand2}";

            default:
                throw new ArgumentOutOfRangeException(nameof(operation), "Unsupported operation");
        }
    }
}
