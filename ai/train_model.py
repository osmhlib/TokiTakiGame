import numpy as np
import tensorflow as tf
from tensorflow.keras import Sequential
from tensorflow.keras.layers import Dense

# Генерація штучних даних
X_train = np.random.rand(1000, 3)  # 1000 прикладів, 3 характеристики (швидкість, здоров'я, шкода)
y_train = np.random.randint(0, 2, 1000)  # Мітки (0 або 1)

# Створення моделі
model = Sequential([
    Dense(10, activation='relu', input_shape=(3,)),  # Перший шар з 10 нейронами
    Dense(1, activation='sigmoid')  # Вихідний шар для бінарної класифікації
])

# Компіляція моделі
model.compile(optimizer='adam', loss='binary_crossentropy', metrics=['accuracy'])

# Навчання моделі
model.fit(X_train, y_train, epochs=10, batch_size=32)

# Збереження моделі у форматі Keras
model_path = "D:\\TokiTakiGame\\ai\\mob_model.keras"
model.save(model_path, save_format='keras')

print(f"Модель збережено за адресою: {model_path}")
