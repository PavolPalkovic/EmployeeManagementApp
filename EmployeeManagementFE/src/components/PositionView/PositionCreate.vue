<template>
    <div class="backdrop" @click.self="close">
        <div class="create">
            <h4>*Name: <input type="text" v-model="position.name"> </h4>
            <h4>Description: <input type="text" v-model="position.description"> </h4>
            <button @click="createPosition(); close();" :disabled="!position.name">Create</button>
            <button @click="close">Cancle</button>
        </div>
    </div>
</template>

<script>
import { postPosition } from '../../requests/requestsPosition'

export default {
    props: [ 'getPositionsParent' ],
    data() {
        return {
            position: {}
        }
    },
    methods: {
        close() {
            this.$emit('closeCreate');
        },
        async createPosition() {
          await postPosition(this.position);
          this.getPositionsParent();
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