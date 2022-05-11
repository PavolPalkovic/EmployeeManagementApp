<template>
    <div class="backdrop" @click.self="close">
        <div class="delete">
            <h4>Do you really want to delete position: {{ position.name }}</h4>
            <button @click="deletePosition(); close();">Yes</button>
            <button @click="close">Cancle</button>
        </div>
    </div>
</template>

<script>
import { deletePosition } from '../../requests/requestsPosition'

export default {
    props: [ 'position', 'getPositionsParent' ],
    methods: {
        close() {
            this.$emit('closeDelete');
        },
        async deletePosition() {
          await deletePosition(this.position.id)
          this.getPositionsParent()
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