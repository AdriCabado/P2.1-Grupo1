# P2.1-Grupo1
Repositorio del proyecto Macedian para la P2 de DXPP

# **Protocolo de Comunicación Interno**

## **1. Introducción**
El objetivo de este protocolo es establecer una guía clara para la resolución de problemas y garantizar una comunicación fluida dentro del equipo. 
Este protocolo se basa en la clasificación de los problemas por su dificultad y la elección de los medios adecuados para abordarlos.
También quedará justificada la creación de branches y merges que se hará a lo largo del proyecto.
Además queda detallada una guía de creación de issues en caso de problemas complejos para tener como base llegada su necesidad.

---

## **2. Clasificación de Problemas por Dificultad**

### **Categoría 1 (Little problem in ChinaTown): Problemas simples o de bajo impacto**
- **Ejemplos:**
  - Duda rápida sobre el uso de una herramienta.
  - Confirmación de una tarea asignada.
  - Incertidumbre sobre pequeños detalles de diseño o funcionalidad.
- **Resolución:**
  - Usar mensajería rápida como WhatsApp o Discord.
  - **Tiempo de respuesta esperado:** 10-15 minutos.
- **Pasos:**
  1. Plantear el problema.
  2. Esperar respuesta del compañero involucrado o del Project Manager

---

### **Categoría 2 (Jefe, he abierto un correo que no debía): Problemas técnicos de dificultad media/alta**
- **Ejemplos:**
  - Error al intentar ejecutar el código o utilizar dependencias.
  - Incertidumbre sobre cómo implementar una funcionalidad.
  - Dudas sobre cómo resolver un conflicto de ramas en Git.
- **Resolución:**
  - Usar canales dedicados en Discord o una videollamada rápida.
  - Crear una **issue** detallada en GitHub para documentar y dar seguimiento al problema.
  - **Tiempo de respuesta esperado:** 30min-1 día
- **Pasos:**
  1. Explica el problema claramente, indicando los pasos seguidos y el error encontrado.
  2. Si es necesario, comparte capturas de pantalla o enlaces al código relevante.
  3. Coordina una llamada si no se resuelve en el chat.

---

## **3. Creación de branches y merges**
  - Al principio de cada semana se realizará una rama por usuario en la que se irán realizando los avances y ajustes
  - Al acabar las tareas adjudicadas para esa semana, se dará por conseguido el objetivo y se realizarán los 3 merges en main. Cerrando la versión definida para el periodo (0.25,0.50,0.75,1.00).



## **4. Guía para Crear una Issue en GitHub**

### **Estructura de una issue bien redactada**

1. **Título:**
   - Describe el problema de forma breve pero clara.
   - Ejemplo: `Error al cargar sprites en la pantalla principal` o `Merge conflict en la rama 'main'`.

2. **Descripción:**
   - Explica el problema en detalle, proporcionando el contexto necesario.
   ```markdown
   ## Descripción
   Al ejecutar el código en la rama `develop`, los sprites de los personajes no se cargan correctamente en la pantalla principal. Se muestra un error relacionado con la ruta de los archivos.

3. **Pasos para reproducir:**
1. Ejecutar el proyecto desde la rama `develop`.
2. Seleccionar "Iniciar Juego" en el menú principal.
3. Observar la pantalla principal: los sprites no se cargan.

4. **Comportamiento esperado:**
Los sprites de los personajes deberían aparecer correctamente en la pantalla principal.

5. **Recursos:**
- Captura del error: [ruta_del_archivo](enlace)



