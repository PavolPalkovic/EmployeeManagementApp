<template>
    <div class="backdrop" @click.self="close">
        <div class="delete">
            <h4>Do you really want to delete position: {{ name }}</h4>
            <button @click="deletePosition(); close();">Yes</button>
            <button @click="close">Cancle</button>
        </div>
    </div>
</template>

<script>
import axios from 'axios'

export default {
    props: [ 'id', 'name', 'getPositionsParent' ],
    methods: {
        close() {
            this.$emit('closeDelete');
        },
        deletePosition() {
            axios.delete('http://localhost:1028/api/positions/' + this.id)
                .then(response => console.log(response))
                .then(() => this.getPositionsParent())
                .catch(error => console.log(error))
        }
    }
}
</script>


<style scoped>
    .delete {
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