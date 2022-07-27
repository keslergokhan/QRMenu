using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using QRMenu.CmsManagement.Core.Application.Concrete.Model;
using QRMenu.CmsManagement.Core.Application.Interfaces.Model;
using QRMenu.CmsManagement.Core.Application.Interfaces.Repositories;
using QRMenu.CmsManagement.Core.Domain.Common;
using QRMenu.CmsManagement.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRMenu.CmsManagement.Infrastructure.Persistence.Concrete.Repositories
{
    public class WriteRepository<TEntity> :BaseRepository<TEntity> ,IWriteRepository<TEntity> where TEntity : BaseEntity
    {
        public WriteRepository(QRMenuContext dbContext) : base(dbContext)
        {

        }

        public async Task<IResultData<Guid>> AddAsync(TEntity entity, bool seve = true)
        
        {
            IResultData<int> seveResult = new ResultData<int>();
            try
            {
                EntityEntry<TEntity> result = await base.Table.AddAsync(entity);
                if (seve)//otomatik kayıt açıksa
                {
                    seveResult = await this.SeveAsync();
                    if (seveResult.Status == Core.Application.Enums.ResultStatusEnum.Success)//sonuc başarılı ve işlem added ise
                        return new ResultData<Guid>().SetDataSuccessMessage(entity.Id,GlobalMessage.globalSuccess);
                    else//sonuc başarısız veya durum added değilse
                        return new ResultData<Guid>().SetDataWarningMessage(entity.Id,seveResult.Message).SetException(seveResult.Exception);
                }

                if (result.State == EntityState.Added)
                    return new ResultData<Guid>().SetDataSuccessMessage(entity.Id, "Ekleme işlemi başarılı");
                else
                    return new ResultData<Guid>().SetDataWarningMessage(entity.Id,"Beklenmedik bir durum oluştu !");
            }
            catch (Exception ex)
            {
                return new ResultData<Guid>().SetDataErrorMessage(entity.Id,ex.Message).SetException(ex);
            }
            finally { seveResult = null; }

        }

        public async Task<IResult> AddRangeAsync(List<TEntity> entity, bool seve = true)
        {
            IResultData<int> seveResult = new ResultData<int>();
            try
            {
                await this.Table.AddRangeAsync(entity);
                if (seve)
                {
                    seveResult = await this.SeveAsync();
                    if (seveResult.Status == Core.Application.Enums.ResultStatusEnum.Success)
                        return new Result().SetSuccessMessage(GlobalMessage.globalSuccess);
                    else
                        return new Result().SetWarningMessage(GlobalMessage.globalWarning);
                }
                return new Result().SetSuccessMessage(GlobalMessage.globalSuccess);
            }
            catch (Exception ex)
            {
                return new Result().SetErrorMessage(ex.Message).SetException(ex);
            }
            finally { seveResult = null; }
        }

        public async Task<IResult> DeleteAsync(TEntity entity, bool seve = true)
        {
            IResultData<int> sevResult;

            try
            {
                IResult result = await Task.Run(() =>
                {
                    EntityEntry<TEntity> removeResutl = base.Table.Remove(entity);
                    if (removeResutl.State == EntityState.Added)
                        return new Result().SetSuccessMessage(GlobalMessage.globalSuccess);
                    else
                        return new Result().SetWarningMessage(String.Format(GlobalMessage.globalWarning+" {0}","DeleteAsync() => Task.Run()"));
                });

                if (seve)
                {
                    sevResult = await this.SeveAsync();
                    if (result.Status == Core.Application.Enums.ResultStatusEnum.Success)
                        return new Result().SetSuccessMessage(GlobalMessage.globalSuccess);
                    else
                        return new Result().SetWarningMessage(GlobalMessage.globalWarning);
                }

                if (result.Status == Core.Application.Enums.ResultStatusEnum.Success)
                    return new Result().SetSuccessMessage(GlobalMessage.globalSuccess);
                else
                    return new Result().SetWarningMessage(GlobalMessage.globalWarning);

            }
            catch (Exception ex)
            {
                return new Result().SetErrorMessage(ex.Message);
            }finally { sevResult = null; }
        }

        public async Task<IResult> DeleteAllAsync(List<TEntity> entities, bool seve = true)
        {
            try
            {
                await Task.Run(() =>
                {
                    base.Table.RemoveRange(entities);
                });

                if (seve)
                {
                    IResultData<int> seveResult = await this.SeveAsync();
                    if (seveResult.Status == Core.Application.Enums.ResultStatusEnum.Success)
                        return new Result().SetSuccessMessage(GlobalMessage.globalSuccess);
                    else
                        return new Result().SetWarningMessage(GlobalMessage.globalWarning);
                }

                return new Result().SetSuccessMessage(GlobalMessage.globalSuccess);
                    
            }
            catch (Exception ex)
            {

                return new Result().SetErrorMessage(ex.Message).SetException(ex);
            }
        }

        

        public async Task<IResult> DeleteByIdAsync(Guid Id, bool seve = true)
        {
            try
            {
                TEntity entity = await this.Table.FindAsync(Id);
                if (entity != null)
                {
                    IResult result = await this.DeleteAsync(entity);
                    if(result.Status == Core.Application.Enums.ResultStatusEnum.Success)
                        return new Result().SetSuccessMessage(GlobalMessage.globalSuccess);
                    else
                        return new Result().SetWarningMessage(result.Message);
                }

                else
                    return new Result().SetWarningMessage("İlgili entity bulunamadı");

            }
            catch (Exception ex)
            {
                return new Result().SetErrorMessage(ex.Message).SetException(ex);
            }
        }

        public async Task<IResult> UpdateAsync(TEntity entity, bool seve = true)
        {
            try
            {
                IResult result = await Task.Run(() =>
                {
                    try
                    {
                        base.Table.Update(entity);
                        return new Result().SetSuccessMessage(GlobalMessage.globalSuccess);
                    }
                    catch (Exception ex)
                    {
                        return new Result().SetErrorMessage(String.Format(GlobalMessage.globalWarning + " {0}", "UpdateAsync() => Task.Run()")).SetException(ex);
                    }
                });

                if (seve)
                {
                    IResultData<int> seveResult = await this.SeveAsync();
                    if (seveResult.Status == Core.Application.Enums.ResultStatusEnum.Success)
                        return new Result().SetSuccessMessage(GlobalMessage.globalSuccess);
                    else
                        return new Result().SetWarningMessage(seveResult.Message);
                }

                if (result.Status == Core.Application.Enums.ResultStatusEnum.Success)
                    return new Result().SetSuccessMessage(GlobalMessage.globalSuccess);
                else
                    throw new Exception(result.Message);
            }
            catch(Exception ex)
            {
                return new Result().SetErrorMessage(ex.Message).SetException(ex);
            }
        }
        public async Task<IResultData<int>> SeveAsync()
        {
            try
            {
                int result = await base._dbContext.SaveChangesAsync();
                if (result > 0)
                    return new ResultData<int>().SetDataSuccessMessage(result, String.Format("Veritabanına {0} adet veri başarıyla kayıt edildi.",result));
                else
                    return new ResultData<int>().SetDataSuccessMessage(result, "Veritabanına kayıt işleminde beklenmedik bir durum oluştu, SeveAsync()");
            }
            catch (Exception ex)
            {
                return new ResultData<int>().SetDataErrorMessage(0, ex.Message).SetException(ex);
            }
        }

        public void Dispoise(bool status)
        {
            if (status)
            {
                this._dbContext.Dispose();
            }
        }

        public void Dispose()
        {
            this.Dispoise(true);
            GC.SuppressFinalize(this);
        }
    }
}
