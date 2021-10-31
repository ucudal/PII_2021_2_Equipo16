# Proyecto_Kick-Off Grupo 16 "NULL"

Nuestro proyecto final de P2.
Proxima entrega miercoles 29 de setiembre, aplicacion de tarjetas CRC y UML.
31/10/21 - Joaquín Pérez
Modificación en BuscadorTags
Comentarios xml en mis clases.

31/10/21 - Tomás Rama
Agregué el método para calcular las ofertas entregadas segun x tiempo en la clase empresa, también se agregó el método AceptarOferta 
la función de ese método es quitar de la lista de Publicaciones, la oferta aceptada, y colocar esa oferta en la lista ofertasAceptadas
de la clase empresa.
Agregué los comentarios XML correspondientes en las clases Empresa y BuscadorUbicación.

31/10/21 Juan Pérez
Modifique Administrador para darle un nombre al administrador. Y le puse los xml.
modifique BuscadorMaterial, le agregue un metodo para recorrer la lista.
modifique Empresa, para solucionar errores que me aparecian.
modifique habilitaciones, para que tuviera una lista de tipo string en lugar de un arraylist y modifique el constructor habilitaciones y arregle los metodos que implementaban. Agregue las xml.
Agregue xml de IHabilitaciones, ITelegram, limpiador de cadena.
Agregue el constructor de Rubro.



30/10/21 - Ramón Lorenzo
Modificadas las clases Oferta: - se añadió un parámetro ID, que es única para cada una de ellas, se utilizó la libreía Guid, para más         facilidad.
                               - se modificaron los métodos AddHabilitacion y RemoveHabilitacion, para que ya no pida el certificador al llamar el método
                               
                       Emprendedor: - se añadieron varios métodos de buscar, por materiales, tags y ubicación. (sujeto a modificación)
                                    - se modificaron los métodos AddHabilitacion y RemoveHabilitacion, para que ya no pida el certificador al llamar el método
                                    - se empieza a añadir el método InteresadoEnOferta


30/10/21 - Tomas Rama
Modifiqué la clase Empresa, para que cumpla con lo que se tenía esperado.
Cuando se crea el producto, se puede poner la cantidad de habilitaciones que quieras, hasta que el usuario no quiera agregar.
Se pueden agregar habilitaciones a nivel de empresa.
Corregido error de que empresa no Implementaba IHabilitaciones bien.
Creadas listas para almacenar cuales ofertas se compraron por un emprendedor(Esto lo acepta la empresa), otra lista para cuales ofertas se interesaron 
los Emprendedores.
Modificado Clase buscador por interfaz.
Agregado BuscadorUbicacion.

30/10/21 - Joaquín Pérez
Clases Rubro y User ya terminadas.
Conflictos resueltos con Empresa y Master.
Vimos de implementar un buscador por interfaz y no como herencia de la forma vista anteriormente.
Cambiada buscador a IBuscador. Creada clase BuscadorTags
30/10/21 - Juan Pérez
Modifique algunas de las cosas que hablamos de la clase Habilitaciones y corregí algunos errores que estaban en el programa.
Dentro de las modificaciones que hice en Habilitaciones, cree la lista y el metodo para poder ver la lista de todas las habilitaciones que hay disponibles.
Corregí algunos errores simples de implementacion que tenia la clase Oferta y Publicaciones.
Cree la clase Limpiador, que permite con un metodo limpiar las cadenas de modo que no importa lo que el usuario ingrese siempre va a trabajar con una cadena que puede reconocer y comparar.
Esto es ya que por ejemplo: EMpresar io   ===>  empresario
                            emPr endE,dor     ===> emprendedor


