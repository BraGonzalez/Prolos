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
                                    tipo = sdr["tipo"].ToString(),
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
        public ActionResult Index(UsuarioModel Model)
        {
            UsuarioModel mo = new UsuarioModel();
            mo = Model;
            try
            {

                string constr = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    Response.Write(mo.id_Usuario);
                    string query = "INSERT INTO prolos.tb_usuario(id_usuario,nombre,apellido,correo,tipo,contraseña) VALUES ('" + mo.id_Usuario + "','" + mo.nombre + "','" + mo.apellido + "','" + mo.correo + "','" + mo.tipo + "','" + mo.contraseña + "');";

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

                    return RedirectToAction("Index", "Usuario");
                }

            }
            catch (Exception)
            {
                throw;
            }

        }


    }
}
