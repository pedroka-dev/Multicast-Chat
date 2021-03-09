# Introduction
To further demonstrate the capabilities of Multicasting and Symmetric Encryption, the goal of this project is to create multicast chat with optional message cryptography. 

In this project the user can send and receive chat messages from other users communicating with a multicast address.  If desired, the user can encrypt his messages using the Advanced Encryption Standard (AES), also knwon as Rijndael. The algorithm key should be a customizable string that converts into a key, while the Initialization vector being be derived directly from the key.

Keep in mind that deriving the IV from the key instead of generating a random value is NOT the best practice. This just has been done for demonstration purposes. 

<details>
<summary>Introdução (Português)</summary>
  
Para demonstrar mais além as capacidades do Multicasting e Criptografia Simétrica, o objetivo deste projeto é criar um chat multicast com criptografia opcional de mensagens.

Neste projeto usuário pode mandar e receber mensage para outros usuário se comunicando com o endereço multicast. Se desejado, o usuário pode criptografar sua mensagem usando  Advanced Encryption Standard (AES), também conhecido como Rijndael. A chave do algoritmo deve ser uma string customizada que é convertida em uma chave, com o Vetor de Inicialização sendo derivado diretamente da chave.

Tenha em mente que derivar o IV da chave ao invés de gerar um valor aleatório NÂO é a melhor prática. Isso só foi feito para fins de demonstração.
</details>


![alt text](https://raw.githubusercontent.com/pedro-ca/Multicast-chat/main/MulticastChat/Images/ChatInitialState.JPG)

# Technical Details
The chat is WindowsForms made on C# .NET Framework v4.7.2, utilizing the UdpClient from the library System.Net.Sockets to communicate of a Multicast Address and Port of the .ser's choice.

Encryption can be optionally toggled on. Utilizing the Advanced Encryption Standard (AES), the user can choose any string smaller or equal to 16 characters as key. The 16 characters length has been choosed because this format is both compatible with key and IV with least conversions, as 16 character string has always raw 128 bits after conversion from the UTF-8 format. 

Someone with an encryption key can read all messages by either anyone with the same key and with no key at all. However, a user without a key can only read messages from someone also without a key, while the rest of the encrypted messages are received as "corrupted characters". 


<details>
<summary>Detalhes Técnicos (Português)</summary>
  
O chat é um WindowsForms feito em C# .NET Framework v4.7.2, utilizando o UdpClient da library System.Net.Sockets para se comunicar com o Endereço Multicast e Porta da escolha do usuário. 

Criptografica pode ser opcionalmente ligada. Utilizando Advanced Encryption Standard (AES), o usuário pode escolher qualquer string menor ou igual a 16 caracteres como chave. O comprimento de 16 caracteres foi escolhido pois esse formato é compativel com chave e IV com menos conversões, porque 16 strings de 16 caracteres possuem sempre 128 bits brutos depois da conversão vinda do formato UTF-8.

Alguém com a chave de criptografia pode ler todas as mensagems com tanto qualquer um com a mesma chave como alguém sem nenhuma chave. Porém, um usário sem nenhuma chave pode somente ler mensagens de alguém também sem chave, enquanto o resto das mensagens criptografadas são recebidas como caracteres corrompidos.
</details>

![alt text](https://raw.githubusercontent.com/pedro-ca/Multicast-chat/main/MulticastChat/Images/rijandel.png)

# Screenshots

![alt text](https://raw.githubusercontent.com/pedro-ca/Multicast-chat/main/MulticastChat/Images/ChatNoCrypto.JPG)


![alt text](https://github.com/pedro-ca/Multicast-chat/blob/main/MulticastChat/Images/ChatWithCrypto1.JPG)


![alt text](https://github.com/pedro-ca/Multicast-chat/blob/main/MulticastChat/Images/ChatWithCrypto2.JPG)


