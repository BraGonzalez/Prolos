using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PROLOSENLINEA.Models;
using MySql.Data.MySqlClient;
using System.Configuration;


namespace PROLOSENLINEA.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        [HttpGet]
        public ActionResult Index()
        {
            try
            {

                List<UsuarioModel> usuario = new List<UsuarioModel>();

                string constr = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    string query = "SELECT * FROM tb_usuario";
                    using (MySqlCommand cmd = new MySqlCommand(query))
                    {
                        cmd.Connection = con;
                        con.Open();
                        using (MySqlDataReader sdr = cmd.ExecuteReader())
                        {
                            while (sdr.Read())
                            {
                                usuario.Add(new UsuarioModel
                                {

                                    id_Usuario = sdr["id_Usuario"].ToString(),
                                    nombre = sdr["nombre"].ToString(),
                                    apellido = sdr["apellido"].ToString(),
                                    correo = sdr["correo"].ToString(),
                                    //tipo = sdr["tipo"].ToString(),
                                    contraseña = sdr["contraseña"].ToString()

                                });
                            }
                        }
                        con.Close();
                    }
                }

                return View(usuario);
            }
            catch (Exception ex)
            {

                return View("Index");

            }
        }


        [HttpPost]
        public ActionResult Index(Guardar Model, elmentinput boton, EditarUsuario Edita, EliminaUsuario Elimina)

        {
            if (boton.btn == "Guardar")
            {
                try
                {
                    Model.tipo = "Cliente";
                    string constr = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
                    using (MySqlConnection con = new MySqlConnection(constr))
                    {
                        Response.Write(Model.id_Usuario);
                        string query = "INSERT INTO prolos.tb_usuario(id_usuario,nombre,apellido,correo,tipo,contraseña) VALUES ('" + Model.id_Usuario + "','" + Model.nombre + "','" + Model.apellido + "','" + Model.correo + "','" + Model.tipo + "','" + Model.contraseña + "');";

                        {
                            MySqlConnection MyConn = new MySqlConnection(constr);
                            MySqlCommand MyComand = new MySqlCommand(query, MyConn);
                            MySqlDataReader myReader;
                            MyConn.Open();
                            myReader = MyComand.ExecuteReader();

                            while (myReader.Read())
                            {
                            }
                            MyConn.Close();
                        }
                    }

                    return Json(new { success = true });
                }
                catch (Exception)
                {
                    return Json(new { success = false });
                }


            }
            else if (boton.btn == "Editar")
            {
                try
                {
                    string constr = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
                    using (MySqlConnection con = new MySqlConnection(constr))
                    {

                        string query1 = "UPDATE prolos.tb_usuario SET nombre = '" + Edita.nomb + "', apellido = '" + Edita.ape + "', correo = '" + Edita.cor + "', contraseña = '" + Edita.cont + "' where id_usuario = '" + Edita.id_user + "';";

                        {
                            MySqlConnection MyConn = new MySqlConnection(constr);
                            MySqlCommand MyComand = new MySqlCommand(query1, MyConn);
                            MySqlDataReader myReader;
                            MyConn.Open();
                            myReader = MyComand.ExecuteReader();

                            while (myReader.Read())
                            {
                            }
                            MyConn.Close();
                        }
                    }
                    return Json(new { success = true });
                }
                catch
                {
                    return Json(new { success = false });
                }

            }
            else if (boton.btn == "Eliminar")
            {
                //eliminar
                try
                {

                    string constr = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
                    using (MySqlConnection con = new MySqlConnection(constr))
                    {
                        Response.Write(Elimina.id_usu);
                        string query2 = "delete from prolos.tb_usuario where id_usuario= '" + Elimina.id_usu + "';";

                        {
                            MySqlConnection MyConn = new MySqlConnection(constr);
                            MySqlCommand MyComand = new MySqlCommand(query2, MyConn);
                            MySqlDataReader myReader;
                            MyConn.Open();
                            myReader = MyComand.ExecuteReader();

                            while (myReader.Read())
                            {
                            }
                            MyConn.Close();
                        }
                    }
                    return Json(new { success = true });
                }
                catch
                {
                    return Json(new { success = false });
                }
            }
            return RedirectToAction("Usuario", "Index");
        }
    }
}
