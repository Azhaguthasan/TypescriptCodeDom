using System;
using System.CodeDom;
using System.Collections.Generic;
using TypescriptCodeDom.CodeExpressions.ArgumentReference;
using TypescriptCodeDom.CodeExpressions.ArrayCreate;
using TypescriptCodeDom.CodeExpressions.ArrayIndexer;
using TypescriptCodeDom.CodeExpressions.BaseReference;
using TypescriptCodeDom.CodeExpressions.BinaryOperator;
using TypescriptCodeDom.CodeExpressions.Cast;
using TypescriptCodeDom.CodeExpressions.DefaultValue;
using TypescriptCodeDom.CodeExpressions.DelegateCreate;
using TypescriptCodeDom.CodeExpressions.DelegateInvoke;
using TypescriptCodeDom.CodeExpressions.Direction;
using TypescriptCodeDom.CodeExpressions.EventReference;
using TypescriptCodeDom.CodeExpressions.FieldReference;
using TypescriptCodeDom.CodeExpressions.Indexer;
using TypescriptCodeDom.CodeExpressions.MethodInvoke;
using TypescriptCodeDom.CodeExpressions.MethodReference;
using TypescriptCodeDom.CodeExpressions.ObjectCreate;
using TypescriptCodeDom.CodeExpressions.ParameterDeclaration;
using TypescriptCodeDom.CodeExpressions.Primitive;
using TypescriptCodeDom.CodeExpressions.PropertyReference;
using TypescriptCodeDom.CodeExpressions.PropertySetValue;
using TypescriptCodeDom.CodeExpressions.Snippet;
using TypescriptCodeDom.CodeExpressions.ThisReference;
using TypescriptCodeDom.CodeExpressions.TypeOf;
using TypescriptCodeDom.CodeExpressions.TypeReference;
using TypescriptCodeDom.CodeExpressions.VariableReference;

namespace TypescriptCodeDom.CodeExpressions
{
    public class ExpressionFactory : IExpressionFactory
    {
        private readonly ITypescriptArgumentReferenceExpression _argumentReferenceExpression;
        private readonly ITypescriptArrayCreateExpression _arrayCreateExpression;
        private readonly ITypescriptArrayIndexerExpression _arrayIndexerExpression;
        private readonly ITypescriptBaseReferenceExpression _baseReferenceExpression;
        private readonly ITypescriptBinaryOperatorExpression _binaryOperatorExpression;
        private readonly ITypescriptCastExpression _castExpression;
        private readonly ITypescriptDefaultValueExpression _defaultValueExpression;
        private readonly ITypescriptDelegateCreateExpression _delegateCreateExpression;
        private readonly ITypescriptDelegateInvokeExpression _delegateInvokeExpression;
        private readonly ITypescriptDirectionExpression _directionExpression;
        private readonly ITypescriptEventReferenceExpression _eventReferenceExpression;
        private readonly ITypescriptFieldReferenceExpression _fieldReferenceExpression;
        private readonly ITypescriptIndexerExpression _indexerExpression;
        private readonly ITypescriptMethodInvokeExpression _methodInvokeExpression;
        private readonly ITypescriptMethodReferenceExpression _methodReferenceExpression;
        private readonly ITypescriptObjectCreateExpression _objectCreateExpression;
        private readonly ITypescriptParameterDeclarationExpression _parameterDeclarationExpression;
        private readonly ITypescriptPrimitiveExpression _primitiveExpression;
        private readonly ITypescriptPropertyReferenceExpression _propertyReferenceExpression;
        private readonly ITypescriptPropertySetValueReferenceExpression _propertySetValueReferenceExpression;
        private readonly ITypescriptSnippetExpression _snippetExpression;
        private readonly ITypescriptThisReferenceExpression _thisReferenceExpression;
        private readonly ITypescriptTypeOfExpression _typeOfExpression;
        private readonly ITypescriptTypeReferenceExpression _typeReferenceExpression;
        private readonly ITypescriptVariableReferenceExpression _variableReferenceExpression;
        private readonly Dictionary<Type, IExpression> _expressionMap;

        public ExpressionFactory(ITypescriptArgumentReferenceExpression argumentReferenceExpression,
            ITypescriptArrayCreateExpression arrayCreateExpression,
            ITypescriptArrayIndexerExpression arrayIndexerExpression,
            ITypescriptBaseReferenceExpression baseReferenceExpression,
            ITypescriptBinaryOperatorExpression binaryOperatorExpression,
            ITypescriptCastExpression castExpression,
            ITypescriptDefaultValueExpression defaultValueExpression,
            ITypescriptDelegateCreateExpression delegateCreateExpression,
            ITypescriptDelegateInvokeExpression delegateInvokeExpression,
            ITypescriptDirectionExpression directionExpression,
            ITypescriptEventReferenceExpression eventReferenceExpression,
            ITypescriptFieldReferenceExpression fieldReferenceExpression,
            ITypescriptIndexerExpression indexerExpression,
            ITypescriptMethodInvokeExpression methodInvokeExpression,
            ITypescriptMethodReferenceExpression methodReferenceExpression,
            ITypescriptObjectCreateExpression objectCreateExpression,
            ITypescriptParameterDeclarationExpression parameterDeclarationExpression,
            ITypescriptPrimitiveExpression primitiveExpression,
            ITypescriptPropertyReferenceExpression propertyReferenceExpression,
            ITypescriptPropertySetValueReferenceExpression propertySetValueReferenceExpression,
            ITypescriptSnippetExpression snippetExpression,
            ITypescriptThisReferenceExpression thisReferenceExpression,
            ITypescriptTypeOfExpression typeOfExpression,
            ITypescriptTypeReferenceExpression typeReferenceExpression,
            ITypescriptVariableReferenceExpression variableReferenceExpression)
        {
            _argumentReferenceExpression = argumentReferenceExpression;
            _arrayCreateExpression = arrayCreateExpression;
            _arrayIndexerExpression = arrayIndexerExpression;
            _baseReferenceExpression = baseReferenceExpression;
            _binaryOperatorExpression = binaryOperatorExpression;
            _castExpression = castExpression;
            _defaultValueExpression = defaultValueExpression;
            _delegateCreateExpression = delegateCreateExpression;
            _delegateInvokeExpression = delegateInvokeExpression;
            _directionExpression = directionExpression;
            _eventReferenceExpression = eventReferenceExpression;
            _fieldReferenceExpression = fieldReferenceExpression;
            _indexerExpression = indexerExpression;
            _methodInvokeExpression = methodInvokeExpression;
            _methodReferenceExpression = methodReferenceExpression;
            _objectCreateExpression = objectCreateExpression;
            _parameterDeclarationExpression = parameterDeclarationExpression;
            _primitiveExpression = primitiveExpression;
            _propertyReferenceExpression = propertyReferenceExpression;
            _propertySetValueReferenceExpression = propertySetValueReferenceExpression;
            _snippetExpression = snippetExpression;
            _thisReferenceExpression = thisReferenceExpression;
            _typeOfExpression = typeOfExpression;
            _typeReferenceExpression = typeReferenceExpression;
            _variableReferenceExpression = variableReferenceExpression;

            _expressionMap = new Dictionary<Type, IExpression>();

            ConstructExpressions();
        }

        private void ConstructExpressions()
        {
            _expressionMap[typeof(CodeArgumentReferenceExpression)] = _argumentReferenceExpression;
            _expressionMap[typeof(CodeArrayCreateExpression)] = _arrayCreateExpression;
            _expressionMap[typeof(CodeArrayIndexerExpression)] = _arrayIndexerExpression;
            _expressionMap[typeof(CodeBaseReferenceExpression)] = _baseReferenceExpression;
            _expressionMap[typeof(CodeBinaryOperatorExpression)] = _binaryOperatorExpression;
            _expressionMap[typeof(CodeCastExpression)] = _castExpression;
            _expressionMap[typeof(CodeDefaultValueExpression)] = _defaultValueExpression;
            _expressionMap[typeof(CodeDelegateCreateExpression)] = _delegateCreateExpression;
            _expressionMap[typeof(CodeDelegateInvokeExpression)] = _delegateInvokeExpression;
            _expressionMap[typeof(CodeDirectionExpression)] = _directionExpression;
            _expressionMap[typeof(CodeEventReferenceExpression)] = _eventReferenceExpression;
            _expressionMap[typeof(CodeFieldReferenceExpression)] = _fieldReferenceExpression;
            _expressionMap[typeof(CodeIndexerExpression)] = _indexerExpression;
            _expressionMap[typeof(CodeMethodInvokeExpression)] = _methodInvokeExpression;
            _expressionMap[typeof(CodeMethodReferenceExpression)] = _methodReferenceExpression;
            _expressionMap[typeof(CodeObjectCreateExpression)] = _objectCreateExpression;
            _expressionMap[typeof(CodeParameterDeclarationExpression)] = _parameterDeclarationExpression;
            _expressionMap[typeof(CodePrimitiveExpression)] = _primitiveExpression;
            _expressionMap[typeof(CodePropertyReferenceExpression)] = _propertyReferenceExpression;
            _expressionMap[typeof(CodePropertySetValueReferenceExpression)] = _propertySetValueReferenceExpression;
            _expressionMap[typeof(CodeSnippetExpression)] = _snippetExpression;
            _expressionMap[typeof(CodeThisReferenceExpression)] = _thisReferenceExpression;
            _expressionMap[typeof(CodeTypeOfExpression)] = _typeOfExpression;
            _expressionMap[typeof(CodeTypeReferenceExpression)] = _typeReferenceExpression;
            _expressionMap[typeof(CodeVariableReferenceExpression)] = _variableReferenceExpression;
        }

        public IExpression<T> GetExpression<T>(T expression)
            where T : CodeExpression
        {
            return (IExpression<T>) _expressionMap[expression.GetType()];
        }
    }
}