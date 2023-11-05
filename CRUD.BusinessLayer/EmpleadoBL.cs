﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CRUD.DataLayer;
using CRUD.EntityLayer;

namespace CRUD.BusinessLayer
{
    public class EmpleadoBL
    {
        EmpleadoDL empleadoDL = new EmpleadoDL();

        public List<Empleado>Lista()
        {
          try{
                return empleadoDL.Lista();
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        public Empleado Obtener(int IdEmpleado)
        {
            try
            {
                return empleadoDL.Obtener(IdEmpleado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public bool Crear(Empleado entidad)
        {
            try
            {
                if(entidad.Nombres=="")
                    throw new OperationCanceledException("El nombre no puede ser vacio");

                    return empleadoDL.Crear(entidad);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Editar(Empleado entidad)
        {
            try
            {
                var encontrado = empleadoDL.Obtener(entidad.IdEmpleado);

                if (encontrado.IdEmpleado == 0)
                    throw new OperationCanceledException("No existe el empleado");

                return empleadoDL.Editar(entidad);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Eliminar(int IdEmpleado)
        {
            try
            {
                var encontrado = empleadoDL.Obtener(IdEmpleado);

                if (encontrado.IdEmpleado == 0)
                    throw new OperationCanceledException("No existe el empleado");

                return empleadoDL.Eliminar(IdEmpleado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
