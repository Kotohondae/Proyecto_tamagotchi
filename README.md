# 🎓 Tamagotchi Universitario

**Tamagotchi Universitario** es una simulación de consola desarrollada en C# donde cuidas a un estudiante universitario mientras intenta sobrevivir a la vida académica. Alimentación, estudio, descanso, estrés, eventos aleatorios, retos y minijuegos... ¡todo puede pasar!

---

## 🧠 ¿De qué trata?

El juego simula el día a día de un estudiante en diferentes carreras (Ingeniería, Medicina, Filosofía o Artes). Debes gestionar su bienestar físico, mental y académico para que no colapse antes de graduarse.

Cada acción (comer, dormir, estudiar, trabajar, socializar) afecta sus niveles de hambre, sueño, estrés, estudio y deuda. ¡Cuidado! Si lo descuidas, las consecuencias se sentirán rápido.

---

## 🚀 Características

- ✅ Sistema de barras de estado (hambre, sueño, estrés, estudio, deuda)
- 🎲 Eventos aleatorios cada 3 días (exámenes sorpresa, virus, fiestas, etc.)
- 🧩 Retos mentales por carrera y actividad (trivias, paradojas, lógica, arte...)
- 🕹️ Minijuegos interactivos: Trivia, Memoria y Decisiones
- 🏆 Logros desbloqueables por desempeño
- 📆 Reloj interno que avanza con el juego
- 😵 Comentarios existenciales según el nivel de bienestar

---

## 🎮 Cómo jugar

1. Ejecuta el proyecto (requiere .NET)
2. Elige tu carrera
3. Usa el menú para tomar decisiones día a día:


4. Administra tus recursos sabiamente. Cada decisión tiene consecuencias.
5. Intenta llegar al final con bajo estrés, buena nota y sin deudas.

---

## 📚 Carreras disponibles

| Carrera   | Estilo de juego | Dificultad |
|-----------|------------------|------------|
| Ingeniero | Lógica y matemática | Alta       |
| Médico    | Cálculos y presión | Muy alta   |
| Filósofo  | Preguntas abstractas | Media     |
| Artista   | Creatividad y memoria | Media     |

Cada carrera tiene sus propios retos y restricciones. Por ejemplo, los filósofos no duermen fácilmente, y los médicos apenas pueden socializar.

---

## 🧪 Tecnología usada

- Lenguaje: C#
- Entorno: Consola .NET
- Arquitectura orientada a objetos
- Uso de clases abstractas, listas, acciones (`Action`), y lógica funcional

---

## 📌 Notas de desarrollo

- El sistema de eventos puede estar forzado a 100% de aparición para fines de demostración (`EventosManager.cs`).
- El HUD muestra valores "positivos" (inverso de hambre, sueño, estrés).
- El juego incluye un sistema básico de logros y registro de historial.

---

## 🧠 Programacion orientada a objetos (POO)

En este proyecto se aplicó POO para hacer un sistema mas ordenado y realista.  
Se utilizaron **clases**, **herencia**, **polimorfismo**, **encapsulamiento** y **composicion**.

- Se creo una clase `Universitario` abstracta que tiene lo basico de un estudiante (hambre, sueño, estres, deuda, etc).  
  De ahi heredan las carreras como `Ingeniero`, `Filosofo`, `Medico` y `Artista`.

- Cada carrera sobreescribe metodos como `Dormir`, `Estudiar`, `TrabajoEspecial`, `SocializarOpcion1`, etc.  
  Eso nos deja aplicar el **polimorfismo** para que cada uno actue distinto aunque tengan los mismos metodos.

- Usamos **propiedades** para acceder a los atributos sin que se puedan modificar directamente, asi se mantiene encapsulado.

- Tambien usamos **composicion** con `RetosManager`, que es parte interna del `Universitario`,  
  y **agregacion** con la lista de `Registro` para guardar las acciones que hizo el jugador.

- Hay varias clases **estaticas** como `HUD`, `Animaciones`, `EventosManager`, `LogrosManager`, etc que ayudan en distintas partes sin necesidad de instanciar.

---

## 💡 Uso de LINQ

En varias partes del proyecto se uso **LINQ** para consultar listas de forma mas facil y elegante.

- Por ejemplo en `Program.cs` se usa para ver si hubo estres alto:
  ```csharp
  var picos = u.ConsultarHistorial(r => r.Estres >= 70);
  if (!picos.Any()) ...
  ```

- En `LogrosManager` para desbloquear logros:
  ```csharp
  if (u.ConsultarHistorial(r => r.Estres >= 90).Any() && !logros.Contains(" Al Límite"))
  ```

- En `Universitario` hicimos el metodo:
  ```csharp
  public IEnumerable<Registro> ConsultarHistorial(Func<Registro, bool> filtro) =>
      historial.Where(filtro);
  ```

- Eso permite filtrar el historial segun condiciones y nos deja evitar loops grandes o codigo repetido.  
  Es mas claro, y se usa junto con expresiones lambda (`r => r.Condicion`).

---

No es un proyecto perfecto pero se organizó bien el codigo y se aplicaron varias cosas de POO que ayudan a escalarlo o modificarlo facil despues.
