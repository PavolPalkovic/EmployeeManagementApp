FROM node:lts-alpine

# All commands bellow this will be executed in container's relative path "/app"
WORKDIR /app

COPY package.json .

RUN npm install

# COPY <source of app directory> <destination of directory in container>
COPY . .

# Exposed port by conector
EXPOSE 8080

CMD ["npm", "run", "serve"]