using System.CodeDom;
using System.CodeDom.Compiler;
using TypescriptCodeDom.CodeExpressions;

namespace TypescriptCodeDom.CodeStatements
{
    class TypescriptAttachEventStatement : IStatement
    {
        private readonly IExpressionFactory _expressionFactory;
        private readonly CodeAttachEventStatement _statement;
        private readonly CodeGeneratorOptions _options;

        public TypescriptAttachEventStatement(
            IExpressionFactory expressionFactory,
            CodeAttachEventStatement statement,
            CodeGeneratorOptions options)
        {
            _expressionFactory = expressionFactory;
            _statement = statement;
            _options = options;
        }

        public string Expand()
        {
            var eventExpression = _expressionFactory.GetExpression(_statement.Event).Evaluate(_statement.Event, _options);
            var listenerExpresssion = _expressionFactory.GetExpression(_statement.Listener).Evaluate(_statement.Listener, _options);
            return $"{eventExpression}.push({listenerExpresssion});";
        }
    }
}