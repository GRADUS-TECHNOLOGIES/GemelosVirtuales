# SPECS GEMELO VIRTUAL BANDA TRASPORTADORA V-1.0.0 (GVBT V-1.0.0)

El proyecto **GVBT 1.0.0** es un gemelo virtual inicial de una banda transportadora simple, desarrollado en Unity, cuyo objetivo es simular el movimiento básico de una cinta industrial y la interacción con objetos sobre ella.

Este gemelo virtual servirá como base para futuras versiones con:

- Sensores virtuales.
- Integración IoT/PLC
- Control externo.
- UI Industrial

## Alcance (MVP)

El sistema debe permitir:

- Simular una banda transportadora en movimiento
- Controlarla desde consola con comandos básicos
- Cambiar dirección del movimiento
- Detenerla
- Colocar hasta 3 objetos sobre la banda

## Entorno de desarrollo

| Elemento      | Requisito                                |
| ------------- | ---------------------------------------- |
| Engine        | Unity 2022 LTS o superior                |
| Render        | Built-in o URP (simple)                  |
| Modelos 3D    | Primitivas Unity (Cube, Cylinder, Plane) |
| Input inicial | Consola interna / Debug Commands         |
| Física        | Rigidbody + Colliders                    |

## Componentes principales

### Banda transportadora

#### Modelo

Construida con primitivas:

- Base: Cube (estructura)
- Cinta: Plane o Cube delgado
- Rodillos: Cylinders

#### Propiedades

| Parámetro | Valor inicial      |
| --------- | ------------------ |
| Speed     | 0.5 – 2.0 m/s      |
| Direction | Forward / Backward |
| State     | Running / Stopped  |

### Objetos trasportados

#### Requisitos

- Máximo 3 objetos simultáneos

- Objetos simples (Cube, Sphere, Capsule)

- Se colocan manualmente mediante comando

#### Física

Cada objeto debe tener:

- Rigidbody
- Collider
- Fricción baja para simular cinta

## Funcionalidades principales

### Movimiento de la banda

#### Estados posibles

| Estado   | Descripción          |
| -------- | -------------------- |
| STOPPED  | Banda detenida       |
| FORWARD  | Banda hacia adelante |
| BACKWARD | Banda hacia atrás    |

### Comandos posibles

Control mediante comandos escritos en consola interna.

#### Lista mínima de comandos

| Comando        | Acción                    |
| -------------- | ------------------------- |
| `start`        | Banda hacia adelante      |
| `stop`         | Detener banda             |
| `reverse`      | Banda hacia atrás         |
| `spawn cube`   | Colocar objeto tipo cubo  |
| `spawn sphere` | Colocar esfera            |
| `clear`        | Eliminar objetos en banda |

## Arquitectura básica del proyecto

### Scripts esenciales

| Scrip                   | Responsabilidad                                              |
| ----------------------- | ------------------------------------------------------------ |
| `ConveyorController.cs` | - Velocidad<br />-Dirección<br />-Estado                     |
| `CommandConsole.cs`     | - Leer input del usuario<br />- Ejecutar comandos<br />- Imprimir estado |
| `ObjectSpawner.cs`      | - Instanciar objetos<br />- Limitar máximo a 3               |

## Lógica de simulación

### Movimiento de objetos

La banda no se mueve físicamente, sino que aplica fuerza o traslación a objetos encima.

Ejemplo:

- detectar objetos con `OnTriggerStay`
- moverlos con:

```csharp
obj.transform.Translate(direction * speed * Time.deltaTime);
```

## Salida esperada del sistema

El gemelo debe mostrar:

- Banda funcionando visualmente
- Objetos desplazándose
- Consola respondiendo a comandos

Ejemplo:

```mark
> start
Banda en movimiento FORWARD

> spawn cube
Objeto agregado (1/3)

> reverse
Banda en movimiento BACKWARD

> stop
Banda detenida

```

