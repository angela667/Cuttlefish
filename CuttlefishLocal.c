#include <string.h>
#include <unistd.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <stdio.h>
#include <pthread.h>
#include <ctype.h>
#include <mysql/mysql.h>
int contador = 0;
//Estructura necesaria para acceso excluyente
pthread_mutex_t mutex = PTHREAD_MUTEX_INITIALIZER;
int i, j;
int sockets[100];
int puerto = 5065;
char host[30] = "localhost";
char contrasql[30] = "mysqlmysql";

typedef struct{
	char nombre[20];
	int socket;
} Conectado;

typedef struct{
	Conectado conectados [100];
	int num;
} ListaConectados;

typedef struct{
	Conectado conectados[5];
	int num;
	int ID;
	int respuesta;
	int num_invitados;
}Partida;


typedef Partida partidas[100];

ListaConectados miLista;
partidas miPartidas;

int PonConectados(ListaConectados *lista, char nombre[20], int socket)
{
	if (lista->num == 100)
		return -1;
	else{
		strcpy(lista->conectados[lista->num].nombre,nombre);
		lista->conectados[lista->num].socket = socket;
		lista->num++;
		return 0;
	}
}
int BuscarPosicion(ListaConectados *lista, char nombre[20])
{
	int i = 0;
	int encontrado = 0;
	while ((i <= lista->num) && (!encontrado))
	{
		if(strcmp(lista->conectados[i].nombre, nombre))
			encontrado = 1;
		else
			i++;
	}
	if(encontrado == 1)	
		return i;
	else
		return -1;
}

int DameSocket (ListaConectados *lista, char nombre[20]){
	//Devuelve el socket o -1 si no esta en la lista
	int i=0;
	int encontrado=0;
	while ((i< lista->num) && !encontrado)
	{
		if (strcmp(lista->conectados[i].nombre,nombre)==0)
			encontrado =1;
		if(!encontrado)
			i=i+1;
	}
	if (encontrado)
		return lista->conectados [i].socket;
	else
		return -1;
}

int EliminarConectado(ListaConectados *lista, char nombre[20])
{
	int pos = BuscarPosicion(lista, nombre);
	if(pos == -1)
		return -1;
	else
	{
		for(int i = pos; i < lista->num-1; i++)
		{
			strcpy(lista->conectados[i].nombre, lista->conectados[i+1].nombre);
			lista->conectados[i].socket = lista->conectados[i+1].socket;
		}
		lista->num --;
		return 0;
	}
}

void DameConectados(ListaConectados *lista, char conectados[512])
{
	conectados[0] = '\0';
	for(int i = 0; i < lista->num; i++)
		sprintf(conectados, "%s%s/", conectados, lista->conectados[i].nombre);
	char hollii[512];
	strcpy(hollii, conectados);
	sprintf(conectados,"4/%d/%s",lista->num, hollii);
	conectados[strlen(conectados)-1] = '\0';
}

/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

int PonJugadorPartida (Partida *partida,char nombre[20],int socket){
	int encontrado=0;
	int i=0;
	if (partida->num==5)
		return -1;
	else
	{
		while (i<partida->num && encontrado==0 )
		{
			if (strcmp(partida->conectados[i].nombre,nombre)==0)
			{
				encontrado=1;
				break;
			}
			i=i+1;
		}
		
		if (encontrado==0) {
			printf("%s fue añadido correctamente en la partida número: %d en la posicion: %d\n",nombre,partida->ID,partida->num);
			strcpy(partida->conectados[partida->num].nombre,nombre);
			partida->conectados[partida->num].socket=socket;
			partida->num=partida->num+1;
			printf("Número de jugadores en la partida: %d = %d\n",partida->ID,partida->num);
			return 0;
		}
		else
			return -2;
	}
}

int DamePosicionJugadorPartida (Partida partida,char nombre[20])
{
	int i=0;
	int encontrado=0;
	while ((i<partida.num) && !encontrado)
	{
		if (strcmp(partida.conectados[i].nombre,nombre)==0)
			encontrado=1;
		if(!encontrado)
			i=i+1;
	}
	if (encontrado)
		return i;
	else
		return -1;
}

int DameSocketJugadorPartida (Partida partida, char nombre[20]){
	int i=0;
	int encontrado=0;
	while ((i< partida.num) && !encontrado)
	{
		if (strcmp(partida.conectados[i].nombre,nombre)==0)
			encontrado =1;
		if(!encontrado)
			i=i+1;
	}
	if (encontrado)
		return partida.conectados [i].socket;
	else
		return -1;
}


int EliminarJugadorPartida (Partida partida,char nombre[20]) 
{
	int pos = DamePosicionJugadorPartida (partida,nombre);
	if (pos==-1)
		return -1;
	else{
		int i;
		for (i=pos;i<partida.num -1;i++)
			partida.conectados[i]=partida.conectados[i+1];
		
		partida.num--;
		return 0;
	}
}
void DameJugadoresPartida (Partida partida,char conectados[300])
{
	sprintf(conectados,"%d",partida.num);
	int i;
	for (i=0;i<partida.num;i++)
		sprintf(conectados,"%s/%s",conectados,partida.conectados[i].nombre);
}


void Inicializar_Tabla_Partidas(partidas Tabla)
{
	printf("Tabla inicializada correctamente\n");
	int i;
	for (i=0;i<100;i++)
		Tabla[i].num=0;
}

int PonPartida(partidas Tabla,Partida partida)
{
	int encontrado;
	int i=0;
	while ((i<100) && !encontrado)
	{
		if (Tabla[i].num==0)
			encontrado=1;
		i=i+1;
	}
	if (encontrado)
	{
		printf("Partida %d anadida correctamente en la tabla\n",partida.ID);
		Tabla[i]=partida;
		return 0;
	}
	else
		return -1;
}
int DamePosicionPartida(partidas Tabla,Partida partida)
{
	int i=0;
	int encontrado;
	while (i<100)
	{
		if (Tabla[i].ID==partida.ID)
			encontrado=1;
			break;
		i=i+1;
	}
	if (encontrado)
		return i;
	
	else
		return -1;
	
}
int EliminarPartida(partidas Tabla,Partida partida)
{
	int pos=DamePosicionPartida(Tabla,partida);
	if (pos!=-1){
		Tabla[pos].num=0;
		return 0;
	}
	else
		return -1;
}
int DamePosicionPartidaID(partidas Tabla,int ID)
{
	int i=0;
	int encontrado;
	while (i<100)
	{
		if (Tabla[i].ID==ID)
			encontrado=1;
			break;
		i=i+1;
	}
	
	if (encontrado)
		return i;
	
	else
		return -1;
	
}

int EliminarPartidaID(partidas Tabla, int ID)
{
	int pos=DamePosicionPartidaID(Tabla,ID);
	if (pos!=-1){
		Tabla[pos].num=0;
		return 0;
	}	
	else
		return -1;
}



/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
void Eliminar(char nombre[25], char contrasena[25], char respuesta[512])
{
	char consulta[500];
	int numJ;

	conn = mysql_init(NULL);
	if (conn == NULL) {
		printf("Error al crear la conexion1: %u %s\n",
			mysql_errno(conn), mysql_error(conn));
		exit(1);
	}

	conn = mysql_real_connect(conn, "localhost", "root", "mysql", "CuttlefishBBDD", 0, NULL, 0);
	if (conn == NULL)
	{
		printf("Error al inicializar la conexion2: %u %s\n",
			mysql_errno(conn), mysql_error(conn));
		exit(1);
	}

	sprintf(consulta, "DELETE FROM JUGADOR WHERE NOMBRE = '%s' AND Contrasena = '%s'", nombre, contrasena);
	err = mysql_query(conn, consulta);
	if (err != 0)
	{
		printf("Error al insertar datos en la base: %u %s\n", mysql_errno(conn), mysql_error(conn));
		exit(1);
		sprintf(respuesta, "4/Error");
	}

	else
	{
		sprintf(respuesta, "4/SI");
	}
	mysql_close(conn);
}
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

void *AtenderCliente (void *socket)
{

	int sock_conn;
	int *s;
	s= (int *) socket;
	sock_conn= *s;
	
	char peticion[512];
	char respuesta[512];
	int ret;
	
	
	int terminar =0;
	// Entramos en un bucle para atender todas las peticiones de este cliente
	//hasta que se desconecte
	while (terminar ==0)
	{
		// Ahora recibimos la petici?n
		ret=read(sock_conn,peticion, sizeof(peticion));
		printf ("Recibido\n");
		// Tenemos que a?adirle la marca de fin de string 
		// para que no escriba lo que hay despues en el buffer
		peticion[ret]='\0';
		printf ("Peticion: %s\n",peticion);
		// vamos a ver que quieren
		char *p = strtok( peticion, "/");
		int codigo =  atoi (p);
		int numForm;
		char Usuario[20];
		char Contrasena[20];
		char nombre[20];
		i = 0;
		
		char anfitrion [20];
		char invitado[20];
		char invitacion[100];
		int juego;
		int IDpartida;
		
		if (codigo ==1 || codigo == 2 || codigo == 3)
		{
			p = strtok( NULL, "/");
			strcpy (Usuario, p);
			p = strtok( NULL, "/");
			strcpy (Contrasena, p);

			printf ("Codigo: %d, Usuario: %s, Contrasena: %s\n", codigo, Usuario, Contrasena);
			
		}
		
		else if (codigo ==0||ret <= 0)
		{//petici?n de desconexi?n
			int res = EliminarConectado(&miLista, Usuario);
			terminar=1;
		}
		
		if (codigo ==1) { //SIGN UP
			MYSQL *conn = mysql_init(NULL);
			conn = mysql_real_connect(conn, host, "root", contrasql, "CuttlefishBBDD", 0, NULL, 0);
			
			if (conn == NULL){
				printf("Error al conectar con la base de datos.\n");
				sprintf (respuesta,"1/Error al conectar con la base de datos.\n");
				
			}
			
			else {
				//COMPROVEM QUE NO EXISTEIXI L'USUARI
				char consulta[512];
				sprintf(consulta, "SELECT Username FROM Jugadores WHERE Username = '%s'", Usuario);
				int err = mysql_query (conn, consulta);
				MYSQL_RES *ress;
				
				if (err!=0)
				{
					printf ("Error al consultar datos de la base %u %s\n",
							mysql_errno(conn), mysql_error(conn));
					exit (1);
				}
				else {
					ress = mysql_store_result (conn);
					int row;
					row = mysql_num_rows (ress);
					
					if (row != 0){
						printf("Ya existe el nombre de usuario\n");
						sprintf (respuesta,"1/Ya existe el nombre de usuario\n");
					}
					else {
						char sql[500];
						sprintf(sql, "INSERT INTO Jugadores (Username, Contrasena) VALUES ('%s', '%s')", Usuario, Contrasena);
					
						int ret = mysql_query(conn, sql);
						
						if (ret != 0) {
							fprintf(stderr, "Error al insertar el usuario: %s\n", mysql_error(conn));
							sprintf (respuesta,"1/Error al insertar el usuario %s\n", Usuario);
						}
						
						else if (ret == 0){
							printf("Usuario registrado correctamente.\n");
							sprintf (respuesta,"1/Usuario %s registrado correctamente.", Usuario);	
						}
						mysql_close(conn);
					}
				}
			}
		}
		
		else if (codigo ==2){ //LOG IN
			// Conecta con la base de datos
			MYSQL *conn = mysql_init(NULL);
			conn = mysql_real_connect(conn, host, "root", contrasql, "CuttlefishBBDD", 0, NULL, 0);
			if (conn == NULL){
				printf("Error al conectar con la base de datos.\n");
				sprintf (respuesta,"2/Error al conectar con la base de datos.\n");
			}
			else {
				char sql[500];
				sprintf(sql, "SELECT Contrasena FROM Jugadores WHERE Username = '%s'", Usuario);
				int ret = mysql_query(conn, sql);
				
				if (ret != 0) {
					fprintf(stderr, "Error al iniciar sesion: %s\n", mysql_error(conn));
					sprintf (respuesta,"2/Error al iniciar sesion %s\n", Usuario);
				}
				else {
					MYSQL_RES *result = mysql_store_result(conn);
					//MYSQL_RES *res;
					MYSQL_ROW row;
					row = mysql_fetch_row(result);
					
					//int num_filas = mysql_num_rows(result);
					//mysql_free_result(result);
					
					if (row == NULL) {
						printf("Error: el usuario no existe.\n");
						sprintf (respuesta,"2/Error: el usuario no existe.");
					}
					else {
						if (strcmp(row[0], Contrasena) == 0) {
							printf("Sesion iniciada correctamente.\n");
							int res = PonConectados(&miLista, Usuario,sock_conn);
							sprintf (respuesta,"2/Sesion iniciada correctamente/ %s.\n", Usuario);
						}
						else {
							printf("Contrasena incorrecta.\n");
							sprintf (respuesta,"2/Contrasena incorrecta.\n");
						}
					}
					// Cierra la conexión con la base de datos
					mysql_close(conn);
				}
			}
		}
		
		else if (codigo == 3){
			MYSQL *conn = mysql_init(NULL);
			conn = mysql_real_connect(conn, host, "root", contrasql, "CuttlefishBBDD", 0, NULL, 0);
			
			if (conn == NULL){
				printf("Error al conectar con la base de datos.\n");
				sprintf (respuesta,"3/Error al conectar con la base de datos.\n");
			}
			
			else {
				char sql[500];
				sprintf(sql, "SELECT resultado, XP FROM Historiales, Jugadores WHERE (Historiales.id_Jugador = Jugadores.id_Jugadores AND Jugadores.Username = '%s')", Usuario);
				int ret = mysql_query(conn, sql);
				
				if (ret != 0) {
					fprintf(stderr, "Error: %s\n", mysql_error(conn));
					sprintf (respuesta,"3/Error al extraer el historial de %s\n", Usuario);
				}
				else {
					MYSQL_RES *result = mysql_store_result(conn);
					MYSQL_ROW row;
					row = mysql_fetch_row(result);
					
					if (row == NULL) {
						sprintf (respuesta,"3/No hay historial\n");
						printf("No hay historial\n");
					}
					else {
						respuesta[0] = '\0';
						int countt = 0;
						while (row != 0) {

							sprintf (respuesta, "%s%s/%s/",respuesta, row[0], row[1]);
							row = mysql_fetch_row(result);
							countt = countt + 1;
						}
						char aaghhh[512];
						strcpy(aaghhh, respuesta);
						sprintf(respuesta, "3/%d/%s",countt, aaghhh);
						respuesta[strlen(respuesta)-1] = '\0';
					}
					mysql_close(conn);
				}
			}
		}
		else if(codigo==4){
			strcpy(contrasena, p);
				printf("Codigo: %d, Nombre: %s y Contrasena: %s\n", codigo, Usuario, contrasena);
				Eliminar(Usuario, contrasena, result);
				pthread_mutex_lock(&mutex);
				if (strcmp(respuesta, "Error") != 0) {
					r = PonConectados(&lista, nombre, socket);
					DameConectados(&lista, conectados);
					sprintf(respuesta, "%s", result);
					int j;
					while (j < lista.num) {
						write(sockets[j], respuesta, strlen(respuesta));
						j++;
					}
				}
				pthread_mutex_unlock(&mutex);
			}
		}
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		
		else if (codigo == 5){ //Invitar a jugar
		
			char amigo[20];

			p = strtok( NULL, "/");
			IDpartida= atoi(p);		
			p = strtok( NULL, "/");
			strcpy (anfitrion, p);
			p = strtok( NULL, "/");
			strcpy (amigo, p);
			
			// Ya tenemos a los jugadores
			Partida partidA;
			partidA.ID=IDpartida;
				
			
			int sockk=DameSocket(&miLista,anfitrion);
			int sock_amigo=DameSocket(&miLista,amigo);
			
			sprintf(respuesta,"5/%s/%s",anfitrion, amigo);
			write(sock_amigo, respuesta, strlen(respuesta));
			printf("Respuesta: %s \n", respuesta);
			
			
		}

//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

	else if (codigo==6) //peticion de aceptar o declinar una invitacion de partida
		{
			int n=0;
			char amigo[20];
			char res_invitacion[10];
			
			p=strtok(NULL, "/");
			strcpy (anfitrion, p);
			p=strtok(NULL, "/");
			strcpy (amigo, p);

			
			int sockk=DameSocket(&miLista,anfitrion);
			int sock_amigo=DameSocket(&miLista,amigo);
			
			printf("%d %d\n",sockk, sock_amigo);
			
			p=strtok(NULL, "/");
			if (strcmp(p, "SI")==0)
			{
				Partida partidA;
				partidA.ID=IDpartida;
				int anadir_anfitrion = PonJugadorPartida(&partidA,anfitrion,sockk);
				int anadir_amigo = PonJugadorPartida(&partidA,amigo,sock_amigo);
				sprintf(respuesta,"6/YES");
				printf("Que empiece la partida entre %s %s\n" anfitrion, amigo);
				
			}
			else
				sprintf(respuesta,"6/NO");
				printf("rechazado");	
		}
	
		
		
	else if (codigo==7) //enviar mensaje chat
		{
			char mensaje[200];
            p = strtok(NULL, "/");
            if (p != NULL) {
                strcpy(mensaje, p);
                sprintf(respuesta, "7/%s", mensaje);
                printf("Mensaje: %s\n", respuesta);
                int j;
                for (j = 0; j < miLista.num; j++)
                {
					write(miLista.conectados[j].socket, respuesta, strlen(respuesta));
                }
            }
        }
	
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////				
		else if (codigo==8)
		{
			int movimiento;
			p=strtok(NULL, "/");
			movimiento=atoi(p);
			
			switch (movimiento) {
				case 1: 
					sprintf(respuesta, "8/1");
				break;
				case 2:
					sprintf(respuesta, "8/2");
				break;
				case 3:
					sprintf(respuesta, "8/3");
				break;
			 }
		}
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////		
		
		if (codigo !=0)
		{
			printf ("Respuesta: %s\n", respuesta);
			// Enviamos respuesta
			write (sock_conn,respuesta, strlen(respuesta));
		}
		if ((codigo ==1)||(codigo==2)||(codigo==3) || (codigo==4))
		{
			pthread_mutex_lock( &mutex ); //No me interrumpas ahora
			contador = contador +1;
			pthread_mutex_unlock( &mutex); //ya puedes interrumpirme
			// notificar a todos los clientes conectados
			char misConectados[512];
			
			DameConectados(&miLista, misConectados);
			for (j = 0; j < miLista.num; j++)
            {
                write(miLista.conectados[j].socket, misConectados, strlen(misConectados));
            }
		}	
	}

	// Se acabo el servicio para este cliente
	close(sock_conn); 
}

int main(int argc, char *argv[])
{
	ListaConectados miLista;
	int sock_conn, sock_listen;
	struct sockaddr_in serv_adr;
	// INICIALITZACIONS
	// Obrim el socket
	if ((sock_listen = socket(AF_INET, SOCK_STREAM, 0)) < 0)
		printf("Error creant socket");
	// Fem el bind al port
	
	
	memset(&serv_adr, 0, sizeof(serv_adr));// inicialitza a zero serv_addr
	serv_adr.sin_family = AF_INET;
	// asocia el socket a cualquiera de las IP de la m?quina. 
	//htonl formatea el numero que recibe al formato necesario
	
	serv_adr.sin_addr.s_addr = htonl(INADDR_ANY);
	// establecemos el puerto de escucha
	serv_adr.sin_port = htons(puerto);
	if (bind(sock_listen, (struct sockaddr *) &serv_adr, sizeof(serv_adr)) < 0)
		printf ("Error al bind");
	if (listen(sock_listen, 3) < 0)
		printf("Error en el Listen");
	contador =0;
	
	pthread_t thread;
	i=0;
	for (;;){
		printf ("Escuchando\n");
		
		sock_conn = accept(sock_listen, NULL, NULL);
		printf ("He recibido conexion\n");
		sockets[i] =sock_conn;
		//sock_conn es el socket que usaremos para este cliente
		// Crear thead y decirle lo que tiene que hacer
		pthread_create (&thread, NULL, AtenderCliente,&sockets[i]);
		i=i+1;
	}
}

