<template>
    <div class="backdrop" @click.self="close">
        <div class="create">
            <h4>*Name: <input type="text" v-model="positionData.name"> </h4>
            <h4>Description: <input type="text" v-model="positionData.description"> </h4>
            <button @click="createPosition(); close();" :disabled="!positionData.name">Create</button>
            <button @click="close">Cancle</button>
        </div>
    </div>
</template>

<script>
import axios from 'axios'

export default {
    props: [ 'getPositionsParent' ],
    data() {
        return {
            positionData: {
                name: '',
                description: ''
            }
        }
    },
    methods: {
        close() {
            this.$emit('closeCreate');
        },
        createPosition() {
            axios.post('http://localhost:1028/api/positions', this.positionData)
                .then(response => console.log(response))
                .then(() => this.getPositionsParent())
                .catch(error => console.log(error))
        }
    }
}
</script>


<style scoped>
    .create {
        width: 400px;
        padding: 20px;
        margin: 100px auto;
        background: white;
        border-radius: 10px;
    }
    .backdrop {
        top: 0;
        position: fixed;
        background: rgba(0,0,0,0.5);
        width: 100%;
        height: 100%;
    }
</style>