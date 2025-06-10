# Trabajo Práctico: Carrito de Compras

## Enunciado

Se nos encargo el desarrollo del modulo del "carrito de compras" de una aplicacion. El cliente requiere las funcionalidades basicas de un carrito de compras como agregar y eliminar un item al carrito, calcular el precio final a pagar, etc. Tambien tenemos a cargo la implementacion de las clases adicionales necesarias para el correcto funcionamiento del mismo. 

El carrito de compras consta de uno o mas items, donde cada item del carrito se compone por un producto  y la cantidad del mismo que se desea comprar. Cada producto tambien cuenta con una categoria. 

Fecha de revision: 17/6/25 

---

## Objetivo

La aplicación debe modelar un entorno básico de tienda online, donde los usuarios pueden consultar productos agrupados por categoría, seleccionar qué productos agregar a su carrito (respetando el stock disponible) y realizar una compra.

---

## Requisitos funcionales

### 1. Clase `Categoria`
- **Atributos:**
  - Nombre
  - Descripcion

### 2. Clase `Producto`
- **Atributos:**
  - Codigo (int único secuencial)
  - Nombre
  - Precio
  - Stock (cantidad disponible)
  - Categoria (objeto de tipo Categoria)

### 3. Clase `ItemCarrito`
- **Atributos:**
  - Producto
  - Cantidad

### 4. Clase `Carrito`
- **Atributos:**
  - Lista de ItemCarrito

### 5. Clase `Tienda`
- **Atributos:**
  - Lista de productos disponibles
  - Lista de categorías existentes

---

## Requisitos funcionales

El sistema debe presentar un **menú interactivo** que permita al usuario realizar las siguientes acciones:

- Ver todas las **categorías disponibles**
- Ver todos los **productos disponibles**, incluyendo su **stock actual**
- Ver **productos filtrados por categoría**
- **Agregar un producto al carrito** (ingresando código y cantidad)
- **Eliminar un producto del carrito**
- Ver el **contenido del carrito**
- Ver el **total a pagar**
- Finalizar compra
- **Salir** del programa

## EXTRA
Este apartado es **obligatorio para el grupo de 3 integrantes**. Otros grupos que deseen implementar esta funcionalidad tambien pueden hacerlo.

Se desea tambien tener un historial de compras, por lo que luego de cada compra deberan crear un `Ticket` y guardarlo en la Tienda.
El ticket debe tener la fecha en la que se hizo la compra, un ID,los items que se compraron, la cantidad y el precio de cada uno, tambien el total que se pago por la compra.
Ademas deberan agregar una nueva opcion en el menu llamada "Historial de compras" donde se puedan ver un listado de los IDs de los tickets y otra opcion para ver un Ticket dado su ID.

---

## Requisitos técnicos

- Uso correcto de los conceptos de **POO**: clases, objetos, métodos, propiedades, encapsulamiento y composición.
- Separación clara de responsabilidades entre clases.
- Validaciones:
  - Código de producto válido
  - Cantidad positiva
  - Suficiente stock disponible
- Código organizado y legible.

---

## Aclaraciones

- Si se compran 5 unidades del mismo producto, se aplica un 15% de descuento sobre ese producto.
- El total a pagar se calcula como el subtotal de cada producto mas el 21% de IVA.
- Se deben realizar las validaciones que considere necesaria, pero como minimo las mencionadas anteriormente.
- La clase de la **Tienda** debe tener las listas correspondientes inicializadas para testear el programa.
- La opcion de "finalizar compra" debe simular la transaccion, en el sentido de que una vez seleccionada se asume que el cliente paga el monto debido y se reduce el stock de los productos que se acaban de comprar.
- La implementacion queda a cargo de cada grupo pero se deben seguir los lineamiendos planteados en el enunciado. Deben programar todo lo necesario para que el programa sea funcional.
- Se tendra en cuenta el uso de git (commits, ramas, etc).
