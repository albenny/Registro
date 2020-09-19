using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

public class PersonasBLL 
{
    public static bool Guardar(Personas Persona)
    {
        if (!Existe(Persona.PersonasId))
        
            return Insertar(Persona);
        
        else 
        
            return Modificar(Persona);
        
    
    }

    private static bool Insertar(Personas Persona)
    {
        bool paso = false;
        Contexto contexto = new Contexto();
        try 
        {
            contexto.Personas.Add(Persona);
            paso = contexto.SaveChanges() > 0;
        }
        catch(Exception)
        {
            throw;
        }
        finally
        {
            contexto.Dispose();
        }
        return paso;
    }

    private static bool Modificar(Personas Persona)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            
            
            try
            {
                contexto.Entry(Persona).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            

            try
            {
                var Persona = contexto.Personas.Find(id);

                if (Persona != null)
                {
                    contexto.Personas.Remove(Persona);
                    paso = (contexto.SaveChanges() > 0);
                }

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static Personas Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Personas Persona = new Personas() ;

            try
            {
                Persona = contexto.Personas.Find(id);

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return Persona;
        }

        private static bool Existe(int Id)
        {
            Contexto contexto = new Contexto();
            bool guardado = false;

            try
            {
                    guardado=contexto.Personas.Any(e=>e.PersonasId ==Id);}
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return guardado;
        }
}