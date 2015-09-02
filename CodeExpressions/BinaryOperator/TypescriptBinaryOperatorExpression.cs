using System;
using System.CodeDom;
using System.CodeDom.Compiler;

namespace TypescriptCodeDom.CodeExpressions.BinaryOperator
{
    internal class TypescriptBinaryOperatorExpression : ITypescriptBinaryOperatorExpression
    {
        private readonly IExpressionFactory _expressionFactory;

        public TypescriptBinaryOperatorExpression(
            IExpressionFactory expressionFactory)
        {
            _expressionFactory = expressionFactory;
        }


        public string Evaluate(CodeBinaryOperatorExpression codeExpression, CodeGeneratorOptions options)
        {
            var leftExpression = _expressionFactory.GetExpression(codeExpression);
            var leftOperand = leftExpression.Evaluate(codeExpression, options);

            var operatorString = GetOperatorString(codeExpression.Operator);

            var rightExpression = _expressionFactory.GetExpression(codeExpression);
            var rightOperand = rightExpression.Evaluate(codeExpression, options);

            return $"{leftOperand} {operatorString} {rightOperand}";
        }

        private string GetOperatorString(CodeBinaryOperatorType operatorType)
        {
            switch (operatorType)
            {
                case CodeBinaryOperatorType.Add:
                    return "+";
                case CodeBinaryOperatorType.Subtract:
                    return "-";
                case CodeBinaryOperatorType.Multiply:
                    return "*";
                case CodeBinaryOperatorType.Divide:
                    return "/";
                case CodeBinaryOperatorType.Modulus:
                    return "%";
                case CodeBinaryOperatorType.Assign:
                    return "=";
                case CodeBinaryOperatorType.IdentityInequality:
                    return "!=";
                case CodeBinaryOperatorType.IdentityEquality:
                    return "===";
                case CodeBinaryOperatorType.ValueEquality:
                    return "==";
                case CodeBinaryOperatorType.BitwiseOr:
                    return "|";
                case CodeBinaryOperatorType.BitwiseAnd:
                    return "&";
                case CodeBinaryOperatorType.BooleanOr:
                    return "||";
                case CodeBinaryOperatorType.BooleanAnd:
                    return "&&";
                case CodeBinaryOperatorType.LessThan:
                    return "<";
                case CodeBinaryOperatorType.LessThanOrEqual:
                    return "<=";
                case CodeBinaryOperatorType.GreaterThan:
                    return ">";
                case CodeBinaryOperatorType.GreaterThanOrEqual:
                    return ">=";
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}