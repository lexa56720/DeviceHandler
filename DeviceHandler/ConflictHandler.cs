using DeviceHandler.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceHandler
{
    public class ConflictHandler
    {
        private readonly DeviceRepository repository;

        public ConflictHandler(DeviceRepository repository)
        {
            this.repository = repository;
        }

        public async Task<int> HandleConflicts()
        {
            var conflicts = await repository.GetConflicts();
            return await repository.Save(conflicts);
        }
    }
}
