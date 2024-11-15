# Use uma imagem base do Node.js (se for uma aplicação Node)
FROM node:18

# Defina o diretório de trabalho dentro do container
WORKDIR /app

# Copie todos os arquivos do projeto (incluindo package.json) para o container
COPY . .

# Instale as dependências do seu projeto
RUN npm install

# Exponha a porta que sua aplicação usa
EXPOSE 8080

# Defina o comando para rodar a aplicação
CMD ["npm", "start"]
    