# PASO A PASO - CREAR GVBT V-1.0.0

## CREAR EL PROYECTO EN UNITY

### 1. Instalar Unity Hub

Es necesario tener instalado Unity Hub, para ello se descargara desde la página oficial de Unity.

- [Descargar Unity Hub]([Descarga el Unity Hub para comenzar tus proyectos creativos | Unity](https://unity.com/es/download))

### 2. Crear un nuevo proyecto

1. Abrir Unity Hub.

2. Ir a:

   ```markdown
   Projects → New Project
   ```

3. Seleccionar plantilla **3D (Core)**.

4. Nombre del proyecto:

   ```markdown
   GVBT_1_0_0_ConveyorTwin
   ```

5. Click en **Create project**

## Preparar la escena básica

### 3. Crear estructura de carpetas

En el panel Project:

1. Click derecho en Assets
2. Create → Folder

Crear estas carpetas:

```markdown
Assets/
 ├── Scripts
 ├── Scenes
 ├── Prefabs
 └── Materials
```

### 4. Guardar la escena principal

1. Ir a:

   ```markdown
   File → Save As
   ```

2. Guardar como:

   ```markdown
   Scenes/GVBT_MainScene.unity
   ```

## Crear la banda transportadora

### 5. Crear el cuerpo de la banda

1. Hierarchy → Click derecho
2. 3D Object → Cube

Renómbralo:

```markdown
ConveyorBelt
```

#### Ajustar escala de inspector:

```markdown
X = 2
Y = 0.2
Z = 6
```

#### Ajustar posición:

```markdown
X = 0
Y = 0.5
Z = 0
```

### 6. Detección de objetos encima

Seleccionar `ConveyorBelt` y en inspector:

- `Box Collider` activar: `Is Trigger`

Esto permitirá detectar objetos sin bloquearlos.

### 7. Agregar rodillos simples

1. `Hierarchy` → `3D Object` → `Cylinder`

Renombrarlo a `Roller1`

| Tipo     | Valores                       |
| -------- | ----------------------------- |
| Escala   | X = 0.3<br/>Y = 1<br/>Z = 0.3 |
| Rotación | X = 90<br/>Y = 0<br/>Z = 0    |
| Posición | Z = -3                        |

`Ctrl + D` para duplicar y mover el segundo a `Z = +3`

## Crear los scripts

### 8. Crear `ConveyorController.cs`

1. Assets → Scripts
2. Click derecho → Create → C# Script

Nombre `ConveyorController`

### 9. Asignar `ConveyorController` a la banda

1. Seleccionar `ConveyorBelt`
2. Arrastrar el script `ConveyorController` encima

Debe aparecer en Inspector: `Conveyor Controller Component`

### 10. Crear `ObjectSpawner.cs`

1. Assets → Scripts
2. Click derecho → Create → C# Script

Nombre `ObjectSpawner`

## Crear el Spawn Point

### 11. Crear SpawnPoint

1. Hierarchy → Create Empty

Renombrarlo a `SpawnPoint` con una posición:

```markdown
X = 0
Y = 1.0
Z = -2.5
```

### 12. Crear GameObject Spawner

1. Hierarchy → Create Empty

Renombrarlo a `SpawnerSystem`, agregar el script `ObjectSpawner` y en inspector:

- Spawn Point → arrastrar SpawnPoint

## Crear Consola UI dentro del juego

### 13. Crear Canvas

1. Hierarchy → UI → Canvas

Unity crea:

- Canvas
- EventSystem

### 14. Crear Panel Consola

- Canvas → Click derecho → UI → Panel

Con el nombre `ConsolePanel`

### 15. Crear Output Text

- ConsolePanel → UI → Text (Legacy)

Con el nombre `OutputText`

En Inspector:

- Font Size: 18
- Alignment: Upper Left
- Resize Height activado

### 16. Crear InputField

- ConsolePanel → UI → Input Field (Legacy)

Con el nombre `CommandInput`

Colocarlo abajo del panel.

## Script de Consola

### 17. Crear `CommandConsole.cs`

1. Assets → Scripts
2. Click derecho → Create → C# Script

Nombre `CommandConsole`

## Conectar todo

### 18. Crear GameObject ConsoleSystem

1. Hierarchy → Create Empty

Renombrarlo a `ConsoleSystem` y agregar el script `CommandConsole`.

### 19. Arrastrar referencias

Selecciona `ConsoleSystem` y asignar:

| Campo      | Arrastrar     |
| ---------- | ------------- |
| InputField | CommandInput  |
| OutputText | OutputText    |
| Conveyor   | ConveyorBelt  |
| Spawner    | SpawnerSystem |

### 20. Activar Enter

Seleccionar `CommandInput`

- Inspector → On End Edit
  1. Click +
  2. Arrastrar `ConsoleSystem`
  3. Seleccionar `CommandConsole → OnCommandEntered()`