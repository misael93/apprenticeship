exports.Division = (a, b) => {
    b = parseInt(b);
    return (b)
        ? parseInt(a) / b
        : "El divisor no puede ser 0";
}