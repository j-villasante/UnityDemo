# UnityDemo

## Estrucura
Existen dos escenas:
- Game
- Main

Main solo llama a game por un boton.

En la escena Game hay tres botones abajo, uno arriba y un texto. La idea del juego es que aparezca la palabra correcta en el texto 
y que luego el usuario tenga que hacer clic en el boton con la imagen que corresponda. El boton que esta arriba solo pasa a la siguiente 
pregunta sin importar el resto (solo se puso para hacer pruebas).

### Game.cs
Toda la logica esta en este archivo. Este es un modulo de la camara y recibe a través del inspector la referencia a los tres botones y 
al texto. A continuación se explica cada metodo y clases creadas.

##### Attributos
- `leftButton`: Boton de la izquierda.
- `rightButton`: Boton de la derecha.
- `middleButton`: Boton del medio.
- `text`: Intancia del texto.
- `rnd`: Instancia de `System.Random` para generar números aleatorios.
- `availableAnswers`: Es un pool de respuestas que pueden aparecer en el juego. De estas se eligen 3 para cada pregunta.
- `buttons`: Es un arreglo simple de los 3 botones del juego en orden de izquierda a derecha.
- `correctPosition`: Guarda la posición del boton que contiene la posición correcta.

#### Answer
Es una clase que solo se encarga de guardar la palabra que corresponde a la imagen `name`  
y el nombre del archivo de la imagen `image`. Para el ejemplo estos son iguales. Por lo tanto,
tiene dos propiedades: `name` y `image`.

#### Start()
1. Obtiene una nueva instancia de Random que se utiliza durante todo el juego.
2. Coloca todos los botones en una arreglo.
3. Crea un arreglo de Answer. Este contiene todas las respuesta (o opciones) que pueden aparecer en los botones.
4. Corre el metodo Next().

#### Next()
Este metodo se encarga de cambiar la pregunta en el juego. Es decir cambia la palabra mostrada y las imagenes de los botones.
1. Crea una lista aleatoria de `Answer` donde cada elemento dentro de la lista es unico (no esta repetido). 
Utiliza `getRandomUnreapeatedAnswers`
2. Utiliza un `for` de 3 para recorrer todos los botones y colocarle una imagen por cada `Answer` obtenidos anteriormente.
3. Obtiene un numero aleatorio del 0 al 2 y lo coloca en la variable `correctPosition`. Esta parte es clave. Hasta antes de este
punto solo se habia colocado imagenes **únicas** en los botones. Es en este punto que se selecciona cual de los botones tendrá 
la respuesta correcta.
4. Cambia el texto de `text` para que corresponda a la respuesta correcta.

#### getRandomUnreapeatedAnswers()
Este metodo crea una lista de **Answer** donde cada elemento es unico dentro de la lista.
1. Crea una lista vacio de `Answer`
2. Empieza un `do... while` hasta que obtenga una lista que no contenga elementos repetidos. Para esto en cada iteración obtiene un 
número aleatorio para todos las repuestas posibles (en este caso 5) y en base a esta número obtiene una posible respuesta.
Verifica que la respuesta no este contenida en la lista antes creada y si no esta contenida la agrega a la lista.
3. El `while` termina cuando la lista contiene 3 elementos. Son solo 3 por ser solo 3 botones.

### OnLeftClick(), OnMiddleClick() y OnRightClick()
Cada uno de estos metodos corresponda a cada boton. Verifica si el clic es un clic correcto. Para esto cada boton compara
el `correctPosition` de acuerdo al indice que se ha coloca en el método. Si la respuesta es correcta se ejecuta `next()`
y se pasa a la siguiente pregunta.
