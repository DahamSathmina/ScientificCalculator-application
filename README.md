# Scientific Console Calculator

[![.NET](https://img.shields.io/badge/.NET-10.0-blue?logo=dotnet)](https://dotnet.microsoft.com/)
[![Build Status](https://img.shields.io/github/actions/workflow/status/yourusername/ScientificCalculator/dotnet.yml?branch=main)](https://github.com/yourusername/ScientificCalculator/actions)
[![License: MIT](https://img.shields.io/badge/License-MIT-green)](LICENSE)
[![GitHub issues](https://img.shields.io/github/issues/yourusername/ScientificCalculator)](https://github.com/yourusername/ScientificCalculator/issues)

A **feature-rich, console-based scientific calculator** built in **C#**, with color-coded output, history management, and support for advanced mathematical operations. Perfect for developers, students, and math enthusiasts.

---

## Table of Contents

- [Features](#-features)  
- [Installation](#-installation)  
- [Usage](#-usage)  
- [Supported Operations](#-supported-operations)  
- [Examples](#-examples)  
- [Contribution](#-contribution)  
- [License](#-license)  

---

## ⚡ Features

- **Basic Arithmetic:** `+`, `-`, `*`, `/`, `%`  
- **Advanced Operations:** Power `^`, Square Root `√`, Factorial `!`, Absolute Value  
- **Trigonometry:** `sin`, `cos`, `tan` (input in degrees)  
- **Logarithms:** `log` (base 10), `ln` (natural log)  
- **Exponential Functions:** `e^x`  
- **History Management:** View and clear past calculations  
- **Last Result Reuse:** Press Enter to reuse the last result  
- **Error Handling:** Handles invalid input, division by zero, negative square roots, undefined operations  
- **Interactive Console UI:**  
  - Green: Results  
  - Red: Errors  
  - Yellow: Notifications  

---

## 🛠️ Installation

1. Clone the repository:

```bash
git clone https://github.com/yourusername/ScientificCalculator.git
cd ScientificCalculator
```

2. Install [.NET SDK 10.0+](https://dotnet.microsoft.com/download)  
3. Build the project:

```bash
dotnet build
```

4. Run the calculator:

```bash
dotnet run
```

---

## 📐 Supported Operations

| Operation | Input | Description |
|-----------|-------|-------------|
| Addition | Multiple numbers | Sum of numbers |
| Subtraction | Multiple numbers | Sequential subtraction |
| Multiplication | Multiple numbers | Product of numbers |
| Division | Multiple numbers | Handles division by zero |
| Modulus | Multiple numbers | Remainder operation |
| Power | Base and exponent | Exponentiation |
| Square Root | Single number | Only non-negative numbers |
| Factorial | Single number | Only non-negative integers |
| Sin / Cos / Tan | Degrees | Trigonometric calculations |
| Log | Positive numbers | Base 10 logarithm |
| Ln | Positive numbers | Natural logarithm |
| e^x | Single number | Exponential function |
| Abs | Single number | Absolute value |

---

## 💡 Usage Tips

- Press **Enter** to reuse the last calculation result.  
- Use **`done`** to finish multi-number input.  
- View calculation history with **option 16**, clear with **option 17**.  
- Input angles in **degrees** for trigonometric functions.  

---

## Examples

```text
Addition:
Enter choice: 1
Numbers: 5, 10, 15 → Result: 30

Factorial:
Enter choice: 8
Number: 5 → Result: 5! = 120

Square Root:
Enter choice: 7
Number: 16 → Result: √16 = 4

Trigonometry:
Enter choice: 9
Angle: 30 → Result: sin(30°) = 0.5
```

---

## 🤝 Contribution

- Fork the repository  
- Create a new branch: `git checkout -b feature-name`  
- Make your changes  
- Commit: `git commit -m "Add feature"`  
- Push: `git push origin feature-name`  
- Open a Pull Request  

**Suggested improvements:**  
- Add new mathematical functions  
- Improve error handling and UX  
- Add cross-platform or GUI support  

---

## License

This project is licensed under the **MIT License**. See [LICENSE](LICENSE) for details.
