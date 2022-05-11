<template>
  <div>
    <div v-if="componentName == 'componentCreate'">
      <PositionCreate @closeCreate="componentName = ''"
      :getPositionsParent="this.getPositions"/>
    </div>
    <h1>Positions</h1>
    <button @click="showComponent('componentCreate')">Create</button>
    <div v-for="position in positions" :key="position.id">
      <h4>{{ position.name }}</h4>
      <p>{{ position.description }}</p>
      <button @click="showComponent('componentDelete')">Delete</button>
      <div v-if="componentName == 'componentDelete'">
        <PositionDelete @closeDelete="componentName = ''"
        :position="position"
        :getPositionsParent="this.getPositions"/>
    </div>
    </div>
  </div>
</template>

<script>
import PositionCreate from '../components/PositionView/PositionCreate.vue'
import PositionDelete from '../components/PositionView/PositionDelete.vue'
import { getPositions } from '../requests/requestsPosition'

export default {
  name: 'PositionsView',
  components: {
    PositionCreate, PositionDelete
  },
  data() {
    return {
      positions: [],
      componentName: ""
    }
  },
  mounted() {
    this.getPositions()
  },
  methods: {
    async getPositions() {
      this.positions = await getPositions();
    },
    showComponent(componentName) {
      this.componentName = componentName;
    }
  }
}
</script>