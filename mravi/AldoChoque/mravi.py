import math


def linea_cadena_a_lista_enteros(texto):
    lista_cadena = texto.split(" ")
    return list(map(lambda e: int(e), lista_cadena))


def leer_datos():
    numero_nodos = input()
    matriz_arbol = []
    for i in range(int(numero_nodos) - 1):
        linea = input()
        matriz_arbol.append(linea_cadena_a_lista_enteros(linea))
    linea = input()
    cantidad_liquidos = linea_cadena_a_lista_enteros(linea)
    return matriz_arbol, cantidad_liquidos


def calcular_cantidad_liquido_nodo_padre(nodo, cantidad_liquido, matriz):
    for vector in matriz:
        nodo_hijo = vector[1]
        if nodo_hijo is nodo:
            porcentaje = vector[2] / 100
            superpoder = vector[3]
            if superpoder is 1:
                cantidad_liquido = math.sqrt(cantidad_liquido)
            nodo_padre = vector[0]
            cantidad_liquido = cantidad_liquido / porcentaje
            return calcular_cantidad_liquido_nodo_padre(nodo_padre, cantidad_liquido, matriz)
    return cantidad_liquido


def obtener_cantidad_liquido_mayor(matriz_arbol, cantidad_liquidos):
    nodo = 0
    cantidad_liquido_mayor = 0
    for cantidad_liquido in cantidad_liquidos:
        nodo += 1
        if cantidad_liquido > 0:
            cantidad_liquido_actualizado = calcular_cantidad_liquido_nodo_padre(nodo, cantidad_liquido, matriz_arbol)
            if cantidad_liquido_actualizado > cantidad_liquido_mayor:
                cantidad_liquido_mayor = cantidad_liquido_actualizado
    return cantidad_liquido_mayor


def imprimir_resultado(resultado):
    print("{0:.3f}".format(resultado))
    

if __name__ == "__main__":
    matriz_arbol, cantidad_liquidos = leer_datos()
    resultado = obtener_cantidad_liquido_mayor(matriz_arbol, cantidad_liquidos)
    imprimir_resultado(resultado)
