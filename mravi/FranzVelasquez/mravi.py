import math

def lin_cad_list_ente(texto):
    list_cad = texto.split(" ")
    return list(map(lambda e: int(e), list_cad))


def leer_datos():
    num_nodos = input()
    matriz_arbol = []
    for i in range(int(num_nodos) - 1):
        linea = input()
        matriz_arbol.append(lin_cad_list_ente(linea))
    linea = input()
    cant_liquidos = lin_cad_list_ente(linea)
    return matriz_arbol, cant_liquidos


def calcular_cant_liquido_nodo_padre(nodo, cant_liquido, matriz):
    for vector in matriz:
        nodo_hijo = vector[1]
        if nodo_hijo is nodo:
            porcentaje = vector[2] / 100
            superpoder = vector[3]
            if superpoder is 1:
                cant_liquido = math.sqrt(cant_liquido)
            nodo_padre = vector[0]
            cant_liquido = cant_liquido / porcentaje
            return calcular_cantidad_liquido_nodo_padre(nodo_padre, cant_liquido, matriz)
    return cant_liquido


def obtener_cantidad_liquido_mayor(matriz_arbol, cant_liquidos):
    nodo = 0
    cant_liquido_mayor = 0
    for cant_liquido in cant_liquidos:
        nodo += 1
        if cant_liquido > 0:
            cantidad_liquido_actualizado = calcular_cantidad_liquido_nodo_padre(nodo, cantidad_liquido, matriz_arbol)
            if cantidad_liquido_actualizado > cantidad_liquido_mayor:
                cantidad_liquido_mayor = cantidad_liquido_actualizado
    return cantidad_liquido_mayor


def imprimir_resultado(resultado):
    print("{0:.3f}".format(resultado))
    

if __name__ == "__main__":
    matriz_arbol, cant_liquidos = leer_datos()
    resultado = obtener_cantidad_liquido_mayor(matriz_arbol, cantidad_liquidos)
    imprimir_resultado(resultado)