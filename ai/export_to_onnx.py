import tensorflow as tf
import tf2onnx
import os

# Завантаження Keras-моделі
model_path = "D:\\TokiTakiGame\\ai\\mob_model.keras"
model = tf.keras.models.load_model(model_path)

# Конвертація Sequential у Functional API
if isinstance(model, tf.keras.Sequential):
    input_layer = tf.keras.Input(shape=model.input_shape[1:], name="input")
    output_layer = model(input_layer)
    model = tf.keras.Model(inputs=input_layer, outputs=output_layer)

# Визначення специфікації вхідних даних
input_signature = [tf.TensorSpec([None] + list(model.input_shape[1:]), tf.float32, name="input")]

# Конвертація моделі у формат ONNX
onnx_model_path = "D:\\TokiTakiGame\\ai\\mob_model.onnx"
try:
    # Використання tf2onnx для конвертації
    model_proto, _ = tf2onnx.convert.from_keras(
        model, 
        input_signature=input_signature, 
        opset=13,
        output_path=onnx_model_path
    )
    print(f"ONNX модель успішно збережено у файл: {onnx_model_path}")
except Exception as e:
    print(f"Помилка під час конвертації моделі: {str(e)}")

# Перевірка ONNX-моделі
try:
    import onnx
    onnx_model = onnx.load(onnx_model_path)
    onnx.checker.check_model(onnx_model)
    print("ONNX модель є валідною.")
except Exception as e:
    print(f"Помилка під час перевірки ONNX-моделі: {str(e)}")
