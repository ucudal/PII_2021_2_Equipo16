# Proyecto_Kick-Off Grupo 16 "NULL"

Nuestro proyecto final de P2.
Proxima entrega miercoles 29 de setiembre, aplicacion de tarjetas CRC y UML.


1y2/11/21 - Juan Pérez
Realice los test de las clases Administrador, Habilitaciones, LimpiadorCadenas.
Modifique la clase de LimpiadorCadenas, le agregue un nuevo metodo para limpiar cadenas, para cuando no solo se ingresa una palabra. Por ejemplo cuando el usuario indica que quiere "Buscar por materiales" entonces era necesario crear un nuevo metodo que permita hacer esto.
A los metodos de la clase Habilitaciones le agregue que impriman en consola la operacion que realizaron, para saber que realmente esten realizando la operacion correspondiente.

2/11/21 - Piero Saucedo
Creada una nueva clase LogicaEmprendedor y otra nueva clase LogicaBuscadores, comentarios XML incluídos. Modificaciones de comentarios XML en todas las clases (para evitar Warnings).
Resueltos una gran cantidad de Warnings en todas las clases (+400). 
Añadidos exclusiones en el archivo Analyzers.ruleset para ocultar temporalmente algunos Warnings.

1/11/21 - Piero Saucedo
Modificada la clase Logica, comentarios añadidos en la clase Publicaciones (se habían borrado), modificada la clase Publicaciones

1/11/21 - Ramón Lorenzo
-Fixes en clase oferta: problemas con la ID (ya no está en el constructor), métodos de habilitaciones.
-Fixes en clase emprendedor: métodos de buscar, habilitaciones y sus métodos.
-Añadidos todos los comentarios XML en clases Emprendedor, Oferta y BuscadorMaterial.

31/10/21 - Joaquín Pérez
Modificación en BuscadorTags
Comentarios XML en mis clases.

31/10/21 - Piero Saucedo
Comentarios XML añadidos a la clase Publicaciones.
Interfaz IPrinter creada y añadida con comentarios XML, clase ConsolePrinter creada y añadida con comentarios XML.

31/10/21 - Tomás Rama
Agregué el método para calcular las ofertas entregadas segun x tiempo en la clase empresa, también agregué el método AceptarOferta. La función de ese método es quitar de la lista de Publicaciones, la oferta aceptada, y colocar esa oferta en la lista ofertasAceptadas de la clase empresa.
Agregué los comentarios XML correspondientes en las clases Empresa y BuscadorUbicación.

31/10/21 Juan Pérez
Modifiqué Administrador para darle un nombre al administrador y le puse los comentarios XML.
Modifiqué BuscadorMaterial, le agregué un método para recorrer la lista.
Modifiqué Empresa para solucionar errores que me aparecían.
Modifiqué habilitaciones, para que tuviera una lista de tipo string en lugar de un arraylist y modifiqué el constructor habilitaciones y arreglé los métodos que implementaban. Agregué los comentarios XML.
Agregué comentarios XML de IHabilitaciones, ITelegram y LimpiadorCadenas.
Agregué el constructor de Rubro.


30/10/21 - Ramón Lorenzo
Modificadas las clases Oferta: - se añadió un parámetro ID, que es única para cada una de ellas, se utilizó la libreía Guid, para más facilidad.
                               - se modificaron los métodos AddHabilitacion y RemoveHabilitacion, para que ya no pida el certificador al llamar el método.
                               
                       Emprendedor: - se añadieron varios métodos de buscar, por materiales, tags y ubicación. (Sujeto a modificación).
                                    - se modificaron los métodos AddHabilitacion y RemoveHabilitacion, para que ya no pida el certificador al llamar el método.
                                    - se empieza a añadir el método InteresadoEnOferta.


30/10/21 - Tomás Rama
Modifiqué la clase Empresa para que cumpla con lo que se tenía esperado.
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
Vimos de implementar un buscador por interfaz y no por herencia de la forma vista anteriormente.
Cambiada buscador a IBuscador. Creada clase BuscadorTags

30/10/21 - Juan Pérez
Modifiqué algunas de las cosas que hablamos de la clase Habilitaciones y corregí algunos errores que estaban en el programa.
Dentro de las modificaciones que hice en Habilitaciones, cree la lista y el método para poder ver la lista de todas las habilitaciones que hay disponibles.
Corregí algunos errores simples de implementación que tenia la clase Oferta y Publicaciones.
Cree la clase Limpiador, que permite con un metodo limpiar las cadenas de modo que no importa lo que el usuario ingrese siempre va a trabajar con una cadena que puede reconocer y comparar.
Esto es ya que por ejemplo: EMpresar io   ===>  empresario
                            emPr endE,dor     ===> emprendedor


