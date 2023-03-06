using FluentValidation;
using PostSharp.Aspects;
using PostSharp.Serialization;

namespace WebAPI.Aspects
{
    [PSerializable]
    public class ValidationAspect : OnMethodBoundaryAspect
    {
        private Type _validatorType;

        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new Exception();
            }
            _validatorType = validatorType;
        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            var entities = args.Arguments.Where(t => t.GetType() == entityType);

            foreach (var entity in entities)
            {
                var context = new ValidationContext<object>(entity);
                var result = validator.Validate(context);
                if (!result.IsValid)
                {
                    throw new ValidationException(result.Errors);
                }
            }
        }
    }
}
