using FluentValidation;
using MediatR;
using QRMenu.CmsManagement.Core.Application.Concrete.Model;
using QRMenu.CmsManagement.Core.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenu.CmsManagement.Core.Application
{
    
    /// <summary>
    /// MediatR sınıflarında alınan property değerleri valitation kontrolleri için <b>Fluent Valitaion</b> sınıfı üzerinden oluşturulan <b>RuleFor</b> koşullarının Ioc ile gelen requestler ile kontroller edilmesi içingerekli "Depandency Injection" işlemleri uygulanır
    /// </summary>
    /// <typeparam name="TRequest">Gelen request istekleri</typeparam>
    /// <typeparam name="TResponse">Döndürelecek olan response değerleri</typeparam>
    public class ValidationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> validators;

        /// <summary>
        /// Constructor içerisinde uygulanan valitador değerlerini generic IEnumerable ile dahil ediliyor
        /// </summary>
        /// <param name="validators"></param>
        public ValidationBehaviour(IEnumerable<IValidator<TRequest>> validators)
        {
            this.validators = validators;
        }
        /// <summary>
        /// IPipelineBehavior interface implement edilen methodudur<br></br>
        /// Bu handler işlemi ile gelen request değerlerinin validator işlemleri kontrol edilir<br></br>
        /// Doğrulama işlemleri başarılı olması durumunda Middleware Next edilerek işlemlere devam edilmesi sağlanır.<br></br>
        /// Doğrulama başarısız olması halinde Exception fırlatılır
        /// </summary>
        /// <param name="request">Validator işlemlerine tabi olacak requestler</param>
        /// <param name="cancellationToken"></param>
        /// <param name="next">Ioc Middleware adımlarının devam etmesini belirtir</param>
        /// <returns></returns>
        /// <exception cref="FluentValidationException">Hata yakalama işlemleri için Exception sınıfından kalıtım alan <b>FluentValidationException</b> sınıfı kullanılır </exception>
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            // Gelen validators listesi olup olmadığını kontrol ediyoruz...
            
            
            if (validators.Any())
            {
                // Fluent kütüphanesine ait olan ValidationContext sınıfı instance alıyoruz...
                var context = new ValidationContext<TRequest>(request);
                var valitationResults = await Task.WhenAll(validators.Select(v => v.ValidateAsync(context, cancellationToken)));
                var failures = valitationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();
                if (failures.Count != 0)
                    throw new FluentValidationException(new Result().SetErrorMessage(failures.FirstOrDefault().ErrorMessage));
            }
            return await next();
        }
    }
}
