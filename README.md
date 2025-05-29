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

## 📷 Capturas de pantalla

_(Opcional: Puedes incluir imágenes del menú o estados del HUD si las tienes)_

---

## ✍️ Autor

**[Tu Nombre]**  
Proyecto académico de simulación - Programación orientada a objetos

---

## 🧭 Licencia

Este proyecto es de uso académico. Puedes modificarlo y compartirlo con fines educativos.
