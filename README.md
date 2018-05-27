# FaceBot
Rôbo desenvolvido em C# que abre o navegador, realiza o login no facebook e menciona os amigos em posts do facebook.

POC desenvlvida para fins ditáticos.

Algumas Observações:

1 - Algumas classes usadas em divs do facebook são dinâmicas, o que pode quebrar a lógica do robô.
</br>2 - A URL do post na qual o robô irá comentar deve ser inserida no App.config no value = "" da chave "facebookPost".
</br>3 - O uso contínuo desse robõ pod elevar a bloqueios temporários na conta utilizada.
</br>4 - O posts do facebook devem possuir o m de mobile na url: ex -> http://m.facebook/com ...
</br>5 - Este robô necessita do Firefox instalado para funcionar.
