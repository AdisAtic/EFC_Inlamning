using DataLayer.Entities;
using DataLayer.Repositories;

namespace DataLayer.Services
{
    public class RoleService
    {
        private readonly RoleRepository _roleRepository;

        public RoleService(RoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public RoleEntity CreateRole(string roleName)
        {
            var RoleEntity = _roleRepository.Get(x => x.RoleName == roleName);
            RoleEntity ??= _roleRepository.Create(new RoleEntity { RoleName = roleName });

            return RoleEntity;
        }

        public RoleEntity GetRole(string roleName)
        {
            var RoleModel = _roleRepository.Get(x => x.RoleName == roleName);
            return RoleModel;
        }

        public RoleEntity GetRoleById(int id)
        {
            var RoleModel = _roleRepository.Get(x => x.Id == id);
            return RoleModel;
        }

        public IEnumerable<RoleEntity> GetRoles()
        {
            var roles = _roleRepository.GetAll();
            return roles;  //59:41//
        }

        public RoleEntity UpdateRole(RoleEntity roleModel)
        {
            var updatedRoleModel = _roleRepository.Update(x => x.Id == roleModel.Id, roleModel);
            return updatedRoleModel;
        }


        public void DeleteRole(int id)
        {
            _roleRepository.Delete(x => x.Id == id);
        }
    }
}
