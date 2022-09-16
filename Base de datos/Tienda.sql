DROP DATABASE Tienda;
CREATE DATABASE Tienda;
USE Tienda;

CREATE TABLE productos(
id INT AUTO_INCREMENT PRIMARY KEY,
nombre VARCHAR(150),
descripcion VARCHAR(150),
precio VARCHAR(7));


delimiter $$
DROP PROCEDURE if EXISTS insertproducto;
CREATE PROCEDURE insertproducto(
IN _id INT, IN _nombre VARCHAR(150), IN _descripcion VARCHAR(150) ,IN _precio VARCHAR(7)) 
   BEGIN   
   if _id < 0 then
      INSERT INTO Productos VALUES(NULL, _nombre, _descripcion ,_precio); 
   ELSE if _id > 0 then 
      UPDATE Productos SET nombre = _nombre,  descripcion = _descripcion, precio = _precio WHERE id = _id; 
   END if; 
   END if;
   END;
   
   CALL insertproducto(-1,'Coca','Refresco con azucar','16.30');
   
   
delimiter $$
DROP PROCEDURE if EXISTS showproductos;
CREATE PROCEDURE showproductos(IN _filtro VARCHAR(150)) 
   BEGIN 
   SELECT id, nombre, descripcion, precio FROM productos WHERE nombre LIKE _filtro; 
END;
CALL showproductos('%%');


   SELECT * FROM productos;


