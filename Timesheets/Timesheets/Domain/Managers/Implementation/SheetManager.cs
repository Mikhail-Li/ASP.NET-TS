using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Timesheets.Data.Interfaces;
using Timesheets.Domain.Managers.Interfaces;
using Timesheets.Infrastructure.Extensions;
using Timesheets.Models.Entities;
using Timesheets.Models.Dto;
using Timesheets.Domain.Aggregates.SheetAggregate;

namespace Timesheets.Domain.Managers.Implementation
{
    public class SheetManager: ISheetManager
    {
        private readonly ISheetRepo _sheetRepo;

        public SheetManager(ISheetRepo sheetRepo)
        {
            _sheetRepo = sheetRepo;
        }

        public async Task<Sheet> GetSheet(Guid id)
        {
            return await _sheetRepo.GetItem(id);
        }

        public async Task<IEnumerable<Sheet>> GetSheets()
        {
            return await _sheetRepo.GetItems();
        }

        public async Task<Guid> CreateSheet(SheetRequest request)
        {
            request.EnsureNotNull(nameof(request));

            var sheet = SheetAggregate.CreateSheet(request);
               
            await _sheetRepo.Add(sheet);
            
            return sheet.Id;
        }

        public async Task UpdateSheet(Guid sheetId, SheetRequest request)
        {
            request.EnsureNotNull(nameof(request));

            var sheet = await _sheetRepo.GetItem(sheetId);

            var sheetAggregate = SheetAggregate.UpdateSheet(sheetId, request, sheet);

            await _sheetRepo.Delete(sheetId);

            await _sheetRepo.Add(sheetAggregate);
        }

        public async Task DeleteSheet(Guid sheetId)
        {
           await _sheetRepo.Delete(sheetId);
        }

        public async Task ApproveSheet(Guid sheetId)
        {
            var sheet = await _sheetRepo.GetItem(sheetId);

            sheet.ApproveSheet();

            await _sheetRepo.Update(sheet);
        }

        public async Task UnApproveSheet(Guid sheetId)
        {
            var sheet = await _sheetRepo.GetItem(sheetId);

            sheet.UnApproveSheet();

            await _sheetRepo.Update(sheet);
        }

        public async Task ChangeEmployee(Guid sheetId, Guid newEmployeeId)
        {
            var sheet = await _sheetRepo.GetItem(sheetId);

            sheet.ChangeEmployee(newEmployeeId);

            await _sheetRepo.Update(sheet);
        }
    }
}