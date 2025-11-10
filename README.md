# 🐶 PerretesApp

## 🧩 Descripción del proyecto
**PerretesApp** es un proyecto de práctica desarrollado con **.NET 8**, siguiendo una arquitectura **Clean + CQRS (Command Query Responsibility Segregation)**.  
El objetivo es gestionar entidades llamadas **Perretes**, permitiendo crear, consultar, actualizar y listar registros desde un frontend construido con **Blazor WebAssembly** y **MudBlazor**.

Este proyecto sirve como ejemplo de aplicación **modular, mantenible y escalable**, separando de forma clara las responsabilidades entre capas de dominio, infraestructura y presentación.

---

## ⚙️ Tecnologías principales
- **Backend:** ASP.NET Core Web API  
  - Patrón **CQRS** con **Handlers**, **Commands**, **Queries** y **Validators**  
  - **FluentValidation** para validaciones  
  - **Inyección de dependencias** para servicios y repositorios  
- **Frontend:** Blazor WebAssembly  
  - **MudBlazor** para componentes visuales  
  - Comunicación con API mediante servicios tipados (`IPerreteService`)  
- **Arquitectura:** Clean Architecture (capas desacopladas)
  - `Domain` (Entidades)
  - `Application` (CQRS Handlers)
  - `Infrastructure` (Repositorios)
  - `Presentation` (API + Blazor)

---
